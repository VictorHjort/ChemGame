using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystemScript : MonoBehaviour
{
    public TMP_Text point;
    public string PointsText;
    private int fivePoints = 500;
    //private int threePoints = 500;
    //private int twoPoints = 500;
    //private int onePoints = 500;
  
    void Start()
    {
        point.text = PointsText;
    }

    

    public void AddFivePoints(int amount)
    {
        fivePoints += amount;
        point.text = fivePoints.ToString();
        //points += amount;
        // pointText.text = "Points: " + points.ToString();
    }
}
