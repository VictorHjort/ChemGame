using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public TMP_Dropdown TMP_Dropdown;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        
    }
 
    // Update is called once per frame
    void OnDropdownValueChanged(int value)
    {
        // Get the selected option's index and text
        int selectedIndex = TMP_Dropdown.value;
        string selectedOption = TMP_Dropdown.options[selectedIndex].text;

        // Do something with the selected option
        Debug.Log("Selected option: " + selectedOption);
        PlayerPrefs.SetString("TestPersonNumber", selectedOption);
    }
}
