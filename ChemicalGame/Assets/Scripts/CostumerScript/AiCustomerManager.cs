using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AiCustomerManager : MonoBehaviour
{

    public GameObject[] AiCustomerArray;
    private int AiCustomerIndex;
    [System.NonSerialized] public GameObject ResultManager;
    [System.NonSerialized] public PointSystemScript points;
    [System.NonSerialized] public int PointResult;

    //            Code overview
    // 
    //        void Start()
    //        void Update()
    // public void Task()
    // public void NewAi()
    //
    //               

    // Start is called before the first frame update
    void Start()
    {
        AiCustomerIndex = 0;
        ResultManager = GameObject.Find("StoringResult");

        for (int i = 1; i < AiCustomerArray.Length; i++)
        {
            AiCustomerArray[i].gameObject.SetActive(false);
        }
        if (AiCustomerArray.Length > 0)
        {
            AiCustomerArray[AiCustomerIndex].gameObject.SetActive(true);
            AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().setRequest();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //This is the function to give the current AI custommer the task
    //the task is "is the recieved object the corrrect" the AICustomer then
    //Checks the object and compare it.
    public void Task(GameObject receivedObject) { 
        AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().CustommerRecieved(receivedObject);

    }
    public void MultiTask(GameObject[] receivedObject)
    {
        AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().CustommerRecievedMulti(receivedObject);
    }
    //This Set the current ai active and the other AICustomers objects to not active.

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
            Cursor.lockState = CursorLockMode.None;
            ResultManager.GetComponent<EndStringPrintout>().PrintText();
            points = GameObject.Find("Points").GetComponent<PointSystemScript>();
            PointResult = points.GetResult();
            SceneManager.LoadScene("EndScene");
            print("the game Is Over ");
            PlayerPrefs.SetInt("Results",PointResult);
            }
        
    }
}
/* if (Input.GetKeyDown(KeyCode.C) && AiCustomerArray[AiCustomerIndex].GetComponent<AiCustomer>().Hint1Bool == true)
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
*/