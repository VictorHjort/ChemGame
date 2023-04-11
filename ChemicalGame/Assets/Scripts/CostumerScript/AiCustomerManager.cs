using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCustomerManager : MonoBehaviour
{

    public GameObject[] AiCustomer;
    private int AiCustomerIndex;

    // Start is called before the first frame update
    void Start()
    {
        AiCustomerIndex = 0;
        for (int i = 1; i < AiCustomer.Length; i++)
        {
            AiCustomer[i].gameObject.SetActive(false);
        }
        if (AiCustomer.Length > 0)
        {
            AiCustomer[AiCustomerIndex].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            NewAi();
        }
    }
    public void NewAi() 
    {
            AiCustomerIndex++;
            if (AiCustomerIndex < AiCustomer.Length)
            {
            AiCustomer[AiCustomerIndex - 1].gameObject.SetActive(false);
            AiCustomer[AiCustomerIndex].gameObject.SetActive(true);
            }
            else
            {
                AiCustomer[AiCustomerIndex - 1].gameObject.SetActive(false);
                AiCustomerIndex = 0;
                AiCustomer[AiCustomerIndex].gameObject.SetActive(true);
                //
                // Finished
                //
            }
        
    }
}
