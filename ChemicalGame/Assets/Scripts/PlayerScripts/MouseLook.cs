using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Drawing;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 1000f;
    public Transform playerBody;
    public bool taskMode = false;

    private float xRotationCamera = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      if (taskMode) 
       {
            
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotationCamera -= mouseY;
        xRotationCamera = Mathf.Clamp(xRotationCamera, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotationCamera, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
       }
    }
}