using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public List<AICustomer> AICustomerList = new List<AICustomer>();
    public bool[] AvailableSpotAtCounter;
    public Transform[] CounterSpot;

    public void IncomingAICustomer()
    {
        AICustomer RandomAICustomer = AICustomerList[Random.Range(0, AICustomerList.Count)];

        for(int i = 0; i < AvailableSpotAtCounter.Length; i++)
        {
            if(AvailableSpotAtCounter[i] == true)
            {
                RandomAICustomer.gameObject.SetActive(true);
                RandomAICustomer.transform.position = CounterSpot[i].position;
                // RandomAIShopper.PositionInHand = i;
                AvailableSpotAtCounter[i] = false;
                AICustomerList.Remove(RandomAICustomer);
                return;
            }
        }
    }
}
