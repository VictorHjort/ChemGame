using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float zoomFOV = 1f;
    [SerializeField] private float originalFOV = 60f;
    public UITilAtommasse tingen;

    private bool isZooming = false;
    private void Start()
    {
        GetComponent<Camera>().fieldOfView = originalFOV;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tingen.isActive = false;
            isZooming = true;
            GetComponent<Camera>().fieldOfView = zoomFOV;
        }

        if (Input.GetMouseButtonUp(1))
        {
            tingen.isActive = false;
            isZooming = false;
            GetComponent<Camera>().fieldOfView = originalFOV;
        }

        if (isZooming)
        {
            GetComponent<Camera>().fieldOfView -= zoomSpeed * Time.deltaTime;
            GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, zoomFOV, originalFOV);
        }
    }
}