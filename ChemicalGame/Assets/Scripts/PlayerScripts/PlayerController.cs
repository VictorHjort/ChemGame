using UnityEngine;
using UnityEngine.AI;
public class CharacterControlScript : MonoBehaviour
{
    //The camera from where the press will be seen
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest, deskDest, guy;
    private bool isPicking, isOn, goingBack = false;
    public GameObject[] elements;
    private OnHover[] onHover = new OnHover[90];
    private int pickedElement, bPickedElement;
    public GameObject atomHolder;
    private GameObject copiedObject;

    private void Start()
    {
        //Getting all the OnHover scripts from the atom elements
        for (int i = 0; i < elements.Length; i++)
        {
            onHover[i] = elements[i].GetComponent<OnHover>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player is picking anything from the shelves in the moment
        if (!isPicking)
        {
            //Checking all atoms if the player is hovering over them, to make sure you can't click anywhere else.
            for (int i = 0; i < onHover.Length; i++)
            {
                isOn = onHover[i].isOver;
                if (isOn)
                {
                    //Breaking ou of the for loop if player is hovering over an element
                    pickedElement = i;
                    break;
                }
            }
        }

        //Check for mouse input and makes sure the player can only press when they aren't walking and is hovering an element
        if (Input.GetMouseButtonDown(0) && !isPicking && isOn)
        {
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                for (int i = 0; i < onHover.Length; i++)
                {
                //Setting all atom boxes as not picked and outline enabled false
                    onHover[i].outline.enabled = false;
                    onHover[i].isPicked = false;
                    onHover[i].picking = true;
                }
                //Setting the chosen atom elements as isPicked true.
                onHover[pickedElement].isPicked = true;

                //Saving the index of the picked atom elements
                bPickedElement = pickedElement;

                //Setting the destination of the agent to the click position 
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);

                //Setting animtaion to run when the agent is going towards an atom element
                playerAnimator.SetTrigger("run");

            }
        }
        //Check if path is created 
        if (player.hasPath && !isPicking)
        {
            //making isPicking true to keep track of if the agent i picking up an atom
            isPicking = true;
            
            //Letting all the onHover scripts know the agent is now picking an element
            for (int i = 0; i < onHover.Length; i++)
            {
                onHover[i].picking = true;
            }
        }

        //Check if player is at pressed destination yet
        else if (!player.hasPath && isPicking)
        {
            //Setting destination back to desk
            player.SetDestination(deskDest.transform.position);

            //Now the agent has picked and isPicking is set to false
            isPicking = false;

            //The picked element is now not picked anymore to make the green outline go away
            onHover[bPickedElement].isPicked = false;

            //Duplicating atom element gameobject
            copiedObject = Instantiate(elements[bPickedElement], atomHolder.transform);
            copiedObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            

            //The player animation is now carrying
            playerAnimator.SetTrigger("carry");

            //The boolean for checking the agent is on the way back is set true
            goingBack = true;
        }

        //Player arrived back at desk
        else if (!player.hasPath && !isPicking && goingBack)
        {
            //Letting all onHover scripts know the player is now back at the desk and not picking anymore.
            for (int i = 0; i < onHover.Length; i++)
            {
                onHover[i].picking = false;
            }

            for (var i = atomHolder.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(atomHolder.transform.GetChild(i).gameObject);
            }


            //Setting the agent animation to idle/stand.
            playerAnimator.SetTrigger("stand");

            //Now we're not going back anymore, we're back at the desk.
            goingBack = false;
        }
    }
}
