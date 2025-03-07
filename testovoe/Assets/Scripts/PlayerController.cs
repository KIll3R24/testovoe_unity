using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public Joystick joystick;
    private CharacterController controller;
    public bool joystickActive = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (joystickActive)
        {
            horizontalInput = joystick.Horizontal;
            verticalInput = joystick.Vertical;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        moveDirection.y -= 9.8f * Time.deltaTime;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}