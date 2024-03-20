using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAndKeyboardMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5f;
    public float sensitivity;
    public Transform orientation;
    float xRotation;
    float yRotation;

    Vector3 movement;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();  
        cam = GameObject.Find("Camera Offset").transform;
    }

    // Update is called once per frame
    void MouseMovement()
    {
        float xInput = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float yInput = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;
        yRotation += xInput;
        xRotation -= yInput;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void KeyboardMovement()
    {
        movement = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");
        controller.Move(movement * Time.deltaTime * speed);
    }
    void Update()
    {
        MouseMovement();
        KeyboardMovement();
    }
}
