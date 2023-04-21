using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    public TMP_Text PointResults;
    private int Results;
    public void Start()
    {
        Results = PlayerPrefs.GetInt("Results");
        PointResults.text = Results.ToString();

    }
}
