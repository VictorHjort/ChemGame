using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    //The camera from where the press will be seen
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest, deskDest, guy;
    private bool isPicking, isOn, goingBack, okPressed, atomChosen;
    public GameObject[] elements, atomDeskPlaces;
    private OnHover[] onHover = new OnHover[90];
    private int pickedElement, bPickedElement;
    public GameObject atomHolder, originalParent;
    private GameObject copiedObject;
    AiCustomerManager theaimanager;
    public bool oneAtomTask, multipleAtomTask, typingTask, wrong;
    private List<int> atomElemIndex = new List<int>();
    RaycastHit point;

    private void Start()
    {
        //Getting all the OnHover scripts from the atom elements
        for (int i = 0; i < onHover.Length; i++)
        {
            
            //onHover[i] = elements[i].GetComponent<OnHover>();
            onHover[i] = elements[i].GetComponent<OnHover>();   
            
        }
        theaimanager = FindObjectOfType<AiCustomerManager>();

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

        if (wrong && multipleAtomTask)
        {
            atomElemIndex.Clear();
            wrong = false;
        }

        //Check for mouse input and makes sure the player can only press when they aren't walking and is hovering an element
        if (Input.GetMouseButtonDown(0) && !isPicking && isOn)
        {
            if (oneAtomTask)
            {
                oneAtomChooseControls();
                print("oneAtomeTask");
            }

            if (multipleAtomTask)
            {
                print("multipleAtomTask");
                multipleAtomChooseControls();
            }
        }
        else if (Input.GetKeyDown("return") && multipleAtomTask && atomChosen)
        {
            //Setting the destination of the agent to the click position 
            targetDest.transform.position = point.point;
            player.SetDestination(point.point);
            //Setting animtaion to run when the agent is going towards an atom element
            playerAnimator.SetTrigger("run");
        }
        else if (Input.GetKeyDown("q") && multipleAtomTask && atomChosen)
        {
            atomChosen = false;
            atomElemIndex.Clear();
            for (int i = 0; i < onHover.Length; i++)
            {
                if (!atomElemIndex.Contains(i))
                {
                    //Setting all atom boxes as not picked and outline enabled false
                    onHover[i].outline.enabled = false;
                    onHover[i].isPicked = false;
                }
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
            if (oneAtomTask)
            {
                oneAtomPickControls();
            }

            if (multipleAtomTask)
            {
                multipleAtomPickControls();
            }
        }

        //Player arrived back at desk
        else if (!player.hasPath && !isPicking && goingBack)
        {
            if (oneAtomTask)
            {
                oneAtomPlaceControls();
            }

            if (multipleAtomTask)
            {
                alkaliPlaceControls();
            }                    
        }
    }

    public void oneAtomChooseControls()
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
    public void multipleAtomChooseControls()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;
        if (!okPressed)
        {
            if (Physics.Raycast(ray, out hitPoint))
            {
                for (int i = 0; i < onHover.Length; i++)
                {
                    if (!atomElemIndex.Contains(i))
                    {
                        //Setting all atom boxes as not picked and outline enabled false
                        onHover[i].outline.enabled = false;
                        onHover[i].isPicked = false;
                    }
                }
                //Setting the chosen atom elements as isPicked true.
                onHover[pickedElement].isPicked = true;
                point = hitPoint;
                //Saving the index of the picked atom elements                
                bPickedElement = pickedElement;
                atomElemIndex.Add(pickedElement);
                atomChosen = true;
            }
            
        }
    }
    public void writingTaskControl()
    {

    }
    public void oneAtomPickControls()
    {
        //Setting destination back to desk
        player.SetDestination(deskDest.transform.position);


        //Now the agent has picked and isPicking is set to false
        isPicking = false;

        //The picked element is now not picked anymore to make the green outline go away
        onHover[bPickedElement].isPicked = false;
        onHover[bPickedElement].outline.enabled = false;

        //Duplicating atom element gameobject
        copiedObject = Instantiate(elements[bPickedElement].transform.parent.gameObject, atomHolder.transform);
        copiedObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);


        //The player animation is now carrying
        playerAnimator.SetTrigger("carry");

        //The boolean for checking the agent is on the way back is set true
        goingBack = true;
    }
    public void multipleAtomPickControls()
    {
        //Setting destination back to desk
        player.SetDestination(deskDest.transform.position);


        //Now the agent has picked and isPicking is set to false
        isPicking = false;

        //The picked element is now not picked anymore to make the green outline go away
        for (int i = 0; i < atomElemIndex.Count; i++)
        {
            onHover[atomElemIndex[i]].isPicked = false;
            onHover[atomElemIndex[i]].outline.enabled = false;
        }

        //Duplicating atom element gameobject
        copiedObject = Instantiate(elements[bPickedElement].transform.parent.gameObject, atomHolder.transform);
        copiedObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);


        //The player animation is now carrying
        playerAnimator.SetTrigger("carry");

        //The boolean for checking the agent is on the way back is set true
        goingBack = true;
    }
    public void oneAtomPlaceControls()
    {
        //Letting all onHover scripts know the player is now back at the desk and not picking anymore.
        for (int i = 0; i < onHover.Length; i++)
        {
            onHover[i].picking = false;
        }
        for (var i = atomDeskPlaces[4].transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(atomDeskPlaces[4].transform.GetChild(i).gameObject);
        }
        copiedObject = Instantiate(atomHolder.transform.GetChild(0).gameObject, atomDeskPlaces[4].transform);
        copiedObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        //Destroys all childs of the AtomHolder
        for (var i = atomHolder.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(atomHolder.transform.GetChild(i).gameObject);
        }


        //Setting the agent animation to idle/stand.
        playerAnimator.SetTrigger("stand");

        //Now we're not going back anymore, we're back at the desk.
        goingBack = false;
        theaimanager.Task(elements[bPickedElement].transform.parent.gameObject);
    }
    public void alkaliPlaceControls()
    {
        //Letting all onHover scripts know the player is now back at the desk and not picking anymore.
        for (int i = 0; i < onHover.Length; i++)
        {
            onHover[i].picking = false;
        }
        for (var i = atomDeskPlaces[4].transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(atomDeskPlaces[4].transform.GetChild(i).gameObject);
        }
        copiedObject = Instantiate(atomHolder.transform.GetChild(0).gameObject, atomDeskPlaces[4].transform);
        copiedObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);        
        //Destroys all childs of the AtomHolder
        for (var i = atomHolder.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(atomHolder.transform.GetChild(i).gameObject);
        }


        //Setting the agent animation to idle/stand.
        playerAnimator.SetTrigger("stand");
        atomChosen = false;

        //Now we're not going back anymore, we're back at the desk.

        goingBack = false;
        GameObject[] Elementssending = new GameObject[atomElemIndex.Count];
        for (int i = 0; i < atomElemIndex.Count; i++)
        {
            Elementssending[i] =  elements[atomElemIndex[i]].transform.parent.gameObject;
        }
        theaimanager.MultiTask(Elementssending);
    }


}
