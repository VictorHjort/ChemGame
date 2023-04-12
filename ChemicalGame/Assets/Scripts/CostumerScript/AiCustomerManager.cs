using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCustomerManager : MonoBehaviour
{

    public GameObject[] AiCustomerArray;
    private int AiCustomerIndex;

    // Start is called before the first frame update
    void Start()
    {
        AiCustomerIndex = 0;


        for (int i = 1; i < AiCustomerArray.Length; i++)
        {
            AiCustomerArray[i].gameObject.SetActive(false);
        }
        if (AiCustomerArray.Length > 0)
        {
            AiCustomerArray[AiCustomerIndex].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Hint1Bool == true)
        {
           // AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Wrong();
        }
        else if (Input.GetKeyDown(KeyCode.C) && AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Hint2Bool == true)
        {
            //AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Wrong();
        }
        else if (Input.GetKeyDown(KeyCode.C) && AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().FailBool == true)
        {
         //   AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Wrong();
            NewAi();
            AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().SetFailBool(false);
        }

    }
    public void Task(GameObject receivedObject) { AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().CustommerRecieved(receivedObject);

    }
    public void NewAi() 
    {
            AiCustomerIndex++;
            if (AiCustomerIndex < AiCustomerArray.Length)
            {
            AiCustomerArray[AiCustomerIndex - 1].gameObject.SetActive(false);
            AiCustomerArray[AiCustomerIndex].gameObject.SetActive(true);
            AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().setRequest();
        }
            else
            {
                AiCustomerArray[AiCustomerIndex - 1].gameObject.SetActive(false);
                AiCustomerIndex = 0;
                AiCustomerArray[AiCustomerIndex].gameObject.SetActive(true);
            //
            // Finished here the ending game should apear
            //
            print("the game Is Over ");

            }
        
    }
}
