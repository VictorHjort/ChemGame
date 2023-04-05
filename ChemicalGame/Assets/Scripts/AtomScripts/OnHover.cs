
using UnityEngine;

public class OnHover : MonoBehaviour
{

    Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }
    

    

    void OnMouseOver()
    {
        outline.enabled = true;
    }

    void OnMouseExit()
    {
        outline.enabled = false;
    }
}
