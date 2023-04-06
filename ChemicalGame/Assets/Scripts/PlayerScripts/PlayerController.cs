using UnityEngine;
using UnityEngine.AI;

public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest, deskDest, guy;
    private bool isPicking, isOn = false;
    public GameObject[] elements;
    private OnHover[] onHover = new OnHover[90];
    private int pickedElement;
    [SerializeField] private DoorScript doorScript;
    private void Start()
    {
        for(int i = 0; i < elements.Length; i++)
        {
            onHover[i] = elements[i].GetComponent<OnHover>();
        }
        //doorScript = GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doorScript.OpenDoor();
            
        }
        if (!isPicking)
        {
            //Checking all elements 
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
       
        //Check for mouse input and makes sure the player can only press when they aren't walking
        if (Input.GetMouseButtonDown(0) && !isPicking && isOn)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            //Nico door script
            

            if (Physics.Raycast(ray, out hitPoint))
            {
                for (int i = 0; i < onHover.Length; i++)
                    {
                        onHover[i].outline.enabled = false;
                    }
                onHover[pickedElement].isPicked = true;
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);
            }
        }
        //Check if path is created tp make isPicking true
        if (player.hasPath && !isPicking)
        {
            isPicking = true;
        }

        //Check if player is at pressed destination yet
        else if (!player.hasPath && isPicking)
        {
            player.SetDestination(deskDest.transform.position);
            isPicking = false;
        }

        //Player arrived back at desk
        else if (!player.hasPath && !isPicking)
        {
           
        }

        //Controls the player animation - Walk animation on movement and Idle when zero movement
        if (player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }

    }

}