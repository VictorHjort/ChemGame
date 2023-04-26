using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestpersonnumberInEndscreeen : MonoBehaviour
{
    string testID;
    TMP_Text TestID;


    private void Awake()
    {
        TestID = GetComponent<TMP_Text>();
        testID = PlayerPrefs.GetString("TestPersonNumber");
        TestID.text = "Test Person:" + testID;
    }
}
