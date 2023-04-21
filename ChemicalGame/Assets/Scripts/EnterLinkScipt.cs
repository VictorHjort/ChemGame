using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLinkScipt : MonoBehaviour
{
    public string Url = "https://www.survey-xact.dk/LinkCollector?key=973M1V6WUKCP";
    // Start is called before the first frame update
    public void OpenUrl()
    {
        Application.OpenURL(Url);
    }

}
