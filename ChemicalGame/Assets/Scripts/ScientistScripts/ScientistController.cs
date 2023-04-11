
using UnityEngine;
using UnityEngine.AI;

public class ScientistController : MonoBehaviour
{

    public NavMeshAgent scientist;
    public Animator scientistAnimator;
    public GameObject scientistTargetDest, scientistDoneDest;
    public bool readyToWalk, doneWithTask, atDestination;
    public GameObject doorObject;
    private DoorScript doorScript;

    // Start is called before the first frame update
    void Start()
    {
        readyToWalk = true;
        doorScript = doorObject.GetComponent<DoorScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToWalk)
        {
            scientist.SetDestination(scientistTargetDest.transform.position);
            doorScript.OpenDoor();
            print("im here");
        }
        if (scientist.hasPath)
        {
            readyToWalk = true;
        }
        if (!scientist.hasPath)
        {

            readyToWalk = false;
            doorScript.CloseDoor();
            
        }

        if (doneWithTask)
        {
            scientist.SetDestination(scientistDoneDest.transform.position);
            //doorScript.OpenDoor();
        }

        if(scientist.velocity != Vector3.zero)
        {
            scientistAnimator.SetBool("isWalking", true);
        }
        else if(scientist.velocity == Vector3.zero)
        {
            scientistAnimator.SetBool("isWalking", false);
        }
    }
}
