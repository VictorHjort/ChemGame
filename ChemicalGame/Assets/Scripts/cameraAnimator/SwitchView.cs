using UnityEngine;

public class SwitchView : MonoBehaviour
{
    public Animator CamZoom;
    public Animation forEvent;
    public AnimationEvent lookAtScreen;
    private bool animationDone;
    public Camera pov, topDown;
  
    // Start is called before the first frame update
    void Start()
    {
        pov.enabled = true;
        topDown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CamZoom.SetBool("isLooking", true);
        }
        if (animationDone)
        {
            pov.enabled = false;
            topDown.enabled = true;
        }
    }

    public void AnimationDone()
    {
        animationDone = true;
    }
}
