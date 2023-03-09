using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to main camera
    [SerializeReference] private Transform cam;

    // speed property, throws error if set negative
    private float speed = 6.0f;
    [SerializeField]
    float speedBacking
    {
        get { return speed; }
        set
        {
            if (value < 0.0f) Debug.LogError("You can't set a negative speed value");
            else speedBacking = value;
        }
    }

    // jump height property, throws error if set negative
    private float jumpHeight = 2.0f;
    [SerializeField]
    float jumpHeightBacking
    {
        get { return jumpHeight; }
        set
        {
            if (value < 0.0f) Debug.LogError("You can't set a negative jump height value");
            else jumpHeightBacking = value;
        }
    }

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private const float gravity = -13.0f;
    private Vector3 velocity;


    private CharacterController controller;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        // get player inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2.0f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            // angle player facing
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // smoothing the value change of angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speedBacking * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeightBacking * -2.0f * gravity);
        }
    }
}
