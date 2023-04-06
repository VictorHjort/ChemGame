using UnityEngine.AI;
using UnityEngine;

public class OnHover : MonoBehaviour
{

    public Outline outline;
    public Camera cam;
    public bool isOver, isPicked, picking;

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void Update()
    {
        if(isPicked)
        {
            outline.enabled = true;
            outline.OutlineColor = Color.green;
        }
        if(!isPicked && picking)
        {
            outline.enabled = false;
        }
    }


    void OnMouseOver()
    {
        if (!isPicked && !picking)
        {
            outline.enabled = true;
        }
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
