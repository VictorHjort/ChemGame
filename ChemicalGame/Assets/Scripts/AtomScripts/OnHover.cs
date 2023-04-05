using UnityEngine.AI;
using UnityEngine;

public class OnHover : MonoBehaviour
{

    public Outline outline;
    public Camera cam;
    public bool isOver, isPicked;

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }
    

    

    void OnMouseOver()
    {
        outline.enabled = true;
        isOver = true;
    }

    void OnMouseExit()
    {
        if (!isPicked)
        {
            outline.enabled = false;
        }
        isOver = false;
    }
}
