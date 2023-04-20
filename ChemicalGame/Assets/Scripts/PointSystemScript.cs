using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystemScript : MonoBehaviour
{
    public TMP_Text pointText;
    private int points = 0;

    public void PointsAdded(int recivedInt)
    {


        if (recivedInt == 0)
        {
            AddPoints(500);
        }
        else if (recivedInt == 1)
        {
            AddPoints(300);
        }
        else if (recivedInt == 2)
        {
            AddPoints(200);
        }
        else if (recivedInt == 3)
        {
            AddPoints(100);
        }
    }


    public void AddPoints(int amount)
    {
        points += amount;
        pointText.text = points.ToString();
    }

    
}