using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 2f;
    float cameraVertRotation = 0f;
    float cameraHorizRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity;

    cameraVertRotation -= inputY;
    cameraVertRotation = Mathf.Clamp(cameraVertRotation, -90f, 90f);
    
    cameraHorizRotation += inputX;
    transform.rotation = Quaternion.Euler(cameraVertRotation, cameraHorizRotation, 0);
    }
}
