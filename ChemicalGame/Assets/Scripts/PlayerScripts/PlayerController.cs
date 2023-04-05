using UnityEngine;
using UnityEngine.AI;

public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;
    public GameObject targetDest, deskDest, guy;
    private bool isPicking = false;

    // Update is called once per frame
    void Update()
    {
        //Check for mouse input and makes sure the player can only press when they aren't walking
        if (Input.GetMouseButtonDown(0) && !isPicking)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDest.transform.position = hitPoint.point;
                player.SetDestination(hitPoint.point);

            }
        }

        //Check if path is created tp make isPicking true
        else if (player.hasPath && !isPicking)
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