using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_movement : MonoBehaviour
{
    public float sensitivity = 2f;
    private Vector3 lastMousePos;
    private Game_Mechanic manager;

    void Update()
    {
        Vector3 delta = Input.mousePosition - lastMousePos;
        float rotationY = delta.y * sensitivity;
        float rotationX = delta.x *sensitivity;
        if (UI_Manager.isPaused)
        {
            transform.Rotate(new Vector3(rotationX, rotationY, 0));

            lastMousePos = Input.mousePosition;
        }
        else return;           
    }       
}
