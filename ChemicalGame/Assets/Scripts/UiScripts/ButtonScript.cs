using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class ButtonScript : MonoBehaviour
{
    string idleGreenColor = "#009619";
    string hoverGreenColor = "#05DB28";
    
    private Color idleGColor;
    private Color hoverGColor;
    private bool yesclicked = false;
    private void Start()
    {
        ColorUtility.TryParseHtmlString(idleGreenColor, out idleGColor);
        ColorUtility.TryParseHtmlString(hoverGreenColor, out hoverGColor);
    }
    void OnMouseDown()
    {
        yesclicked = true;
    }
    void OnMouseUp()
    {
        if (yesclicked)
        {
            yesclicked = false;
        }
    }

    public void OnMouseEnter()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = idleGColor;
    }

    private void OnMouseExit()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = hoverGColor;
    }
}
