using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScientistController : MonoBehaviour
{

    public NavMeshAgent scientist;
    public Animator scientistAnimator;
    public GameObject scientistTargetDest, scientistDoneDest;
    public bool readyToWalk, atDesk, atFinalDestination, correctAnswer, wrongAnswer, atStart, doneWithTask, walking, leftStart;
    public GameObject doorObject, ui, playerCam;
    private DoorScript doorScript;
    private MouseLook mouseLook;
    AiCustomerManager theAIManagaer;
    public GameObject lights;
    private LightIntensity lightIntensity;
    public bool redLights;
    
    

    // Start is called before the first frame update
    void Start()
    {
        readyToWalk = true;
        doorScript = doorObject.GetComponent<DoorScript>();
        mouseLook = playerCam.GetComponent<MouseLook>();
        theAIManagaer = FindObjectOfType<AiCustomerManager>();
        lightIntensity = lights.GetComponent<LightIntensity>();
        ui.SetActive(false);
        if (redLights)
        {
            lightIntensity.lightRed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToWalk)
        {
            scientist.SetDestination(scientistTargetDest.transform.position);

            //Open/not close door
            doorScript.close = false;
            doorScript.open = true;
            if (scientist.hasPath && walking)
            {
                readyToWalk = false;
                leftStart = true;
            }
        }

        if (!scientist.hasPath && leftStart)
        {
            atDesk = true;
            mouseLook.taskMode = true;
            doorScript.open = false;
            doorScript.close = true;
            ui.SetActive(true);
        }

        if (correctAnswer)
        {
            scientistAnimator.SetBool("correctAnswer", true);
            if (!scientistAnimator.GetNextAnimatorStateInfo(0).IsName("Victory"))
            {
                StartCoroutine(WalkOut());
            }
            if (atFinalDestination)
            {
                StartCoroutine(MakeNewAi());
            }
        }

        if (doneWithTask)
        {
            scientistAnimator.SetBool("wrongAnswer", true);
            if (!scientistAnimator.GetNextAnimatorStateInfo(0).IsName("wrongAnswer"))
            {
                StartCoroutine(WalkOut());
            }
            if (atFinalDestination)
            {
                StartCoroutine(MakeNewAi());
            }
        }

        if(wrongAnswer)
        {
            scientistAnimator.SetBool("wrongAnswer", true);
            StartCoroutine(shiftAnimation());
            wrongAnswer = false;
        }        

            if (scientist.velocity != Vector3.zero)
        {
            scientistAnimator.SetBool("isWalking", true);
            walking = true;
        }
        else if(scientist.velocity == Vector3.zero)
        {
            scientistAnimator.SetBool("isWalking", false);
            walking = false;
        }

       
    }

    //Couroutines needing a waitForSecond funciton
    private IEnumerator WalkOut()
    {
        //The couroutine for making the scientist walk out of the door after the animation.
        yield return new WaitForSeconds(4.5f);
        doorScript.close = false;
        doorScript.open = true;
        scientist.SetDestination(scientistDoneDest.transform.position);
        atFinalDestination = true;
        lightIntensity.lightRed = false;
    }
    
    private IEnumerator MakeNewAi()
    {
        yield return new WaitForSeconds(4f);
        theAIManagaer.NewAi();
    }

    private IEnumerator shiftAnimation()
    {
        yield return new WaitForSeconds(1);
        scientistAnimator.SetBool("wrongAnswer", false);
    }        

}
