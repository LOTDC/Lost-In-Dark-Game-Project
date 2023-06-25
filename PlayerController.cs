using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] float jumpSpeed = 5f; // Jump speed

    [Header("Ground Check Setting")]
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;
    bool jumpRequested; // Add this line
    float ySpeed;
    Quaternion targetRotation;

    CameraController cameraController;
    Animator animator;
    CharacterController characterController;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camF = Camera.main.transform.forward;
        Vector3 camR = Camera.main.transform.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        Vector3 moveDir = camF * v + camR * h;

        GroundCheck();

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump")) // Change this line for jump input
            {
                jumpRequested = true; // Add this line
            }
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        if (jumpRequested) // Add this block
        {
            ySpeed = jumpSpeed; // Make character jump
            jumpRequested = false; // Reset flag
        }

        var velocity = moveDir * moveSpeed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (moveDir.magnitude > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));
        animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, groundCheckRadius + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
