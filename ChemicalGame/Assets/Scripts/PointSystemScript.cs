using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystemScript : MonoBehaviour
{
    public TMP_Text pointText;
    private int points = 0;
    private int results;
    private bool added500Points = false;
    private bool added300Points = false;
    private bool added200Points = false;
    private bool added100Points = false;

    // Public field for the AiCustomer object reference
    public AiCustomer aiCustomerScript;

    private void Update()
    {

        results = aiCustomerScript.Results;

        if (results == 0 && !added500Points)
        {
            AddPoints(500);
            added500Points = true;
        }
        else if (results == 1 && !added300Points)
        {
            AddPoints(300);
            added300Points = true;
        }
        else if (results == 2 && !added200Points)
        {
            AddPoints(200);
            added200Points = true;
        }
        else if (results == 3 && !added100Points)
        {
            AddPoints(100);
            added100Points = true;
        }
    }


    public void AddPoints(int amount)
    {
        points += amount;
        pointText.text = points.ToString();
    }

    
}