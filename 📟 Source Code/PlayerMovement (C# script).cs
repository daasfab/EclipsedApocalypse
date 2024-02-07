using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 8f;

    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float sprintSpeed = 12f;
    //public Slider staminaSlider;
    //public float currentStamina = 1f;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.W))
        {
            // Now check if Left Shift is also pressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //while (currentStamina != 0f)
                //{
                //staminaSlider.value = currentStamina - 0.1f;
                //currentStamina = currentStamina - 0.1f;
                Debug.Log("SPRINTING!!!");
                controller.Move(move * sprintSpeed * Time.deltaTime);
                //}

            }
            else
            {
                // Only W is pressed without Left Shift
                Debug.Log("WALKING!!!");
                controller.Move(move * speed * Time.deltaTime);
                //staminaSlider.value = currentStamina + 0.07f;
                //currentStamina = currentStamina + 0.07f;
            }
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}