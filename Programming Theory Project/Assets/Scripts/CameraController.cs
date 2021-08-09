using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sensitivity = 10;
    private float minimumY = -85;
    private float maximumY = 90;
    private float rotationY = 0;
    private float rotationX = 0;
    private Transform cameraTr;

    void Start()
    {
        cameraTr = transform.Find("PlayerCamera");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Mouse look
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        cameraTr.localEulerAngles = new Vector2(-rotationY, rotationX);
    }
}
