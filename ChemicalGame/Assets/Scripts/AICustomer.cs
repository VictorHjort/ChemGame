using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomer : MonoBehaviour
{
    public bool HasPurchased;
    public int Position;
    private AIManager AICustomerMananger;
    Animator AI_Animation;
    string CurrentState;
    const string AI_Idle =  "AI_Idle";
    const string AI_Walk =  "AI_Walk";
    const string AI_Run =  "AI_Run";
    const string AI_Pay =  "AI_Attack";


    private void ChangeAnimationState(string NewAnimationState)
    {
        if (NewAnimationState == CurrentState)
        {
            return;
        }
        AI_Animation.Play(NewAnimationState);
        CurrentState = NewAnimationState;
    }

    private void Start()
    {
        AICustomerMananger = FindObjectOfType<AIManager>();

    }


    private void OnMouseDown()
    {
        if (HasPurchased == false)
        {
            transform.position += Vector3.up * 5;
            HasPurchased = true;
            AICustomerMananger.AvailableSpotAtCounter[Position] = true;
        }
    }
}
