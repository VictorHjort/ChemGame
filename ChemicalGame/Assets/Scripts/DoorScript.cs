using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    public float DoorSpeed;
    public float rightDestination;
    public float leftDestination;
    public float rightCloseDestination;
    public float leftCloseDestination;

    public void OpenDoor()
    {
        Vector3 rightPos = rightDoor.transform.position;
        if (rightPos.z <= rightDestination)
        {
            rightPos.z += DoorSpeed * Time.deltaTime;
        }
        rightDoor.transform.position = rightPos;

        Vector3 leftPos = leftDoor.transform.position;
        if (leftPos.z >= leftDestination)
        {
            leftPos.z += -DoorSpeed * Time.deltaTime;
        }
        leftDoor.transform.position = leftPos;

      

    }
    public void CloseDoor()
    {
        Vector3 rightPos = rightDoor.transform.position;
        if (rightPos.z >= rightCloseDestination)
        {
            rightPos.z += -DoorSpeed * Time.deltaTime;
        }
        rightDoor.transform.position = rightPos;

        Vector3 leftPos = leftDoor.transform.position;
        if (leftPos.z <= leftCloseDestination)
        {
            leftPos.z += +DoorSpeed * Time.deltaTime;
        }
        leftDoor.transform.position = leftPos;

        
    }

   
}


