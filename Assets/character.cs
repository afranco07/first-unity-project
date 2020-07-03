using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    public float jumpForce = 10.0f;
    public Vector3 jump;
    bool jumping;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 0.2f, 0.0f);
        animator = GetComponent<Animator>();
        moveSpeed = 5f;
    }

    void OnCollisionStay() {
        animator.SetBool("isJumping", false);
    }

    void OnCollisionExit() {
        animator.SetBool("isJumping", true);
    }

    // Update is called once per frame
    void Update()
    {
        bool running = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        animator.SetBool("isRunning", running);
        if (Input.GetKeyDown("space")) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(horizontalInput, 0f, verticalInput);
        transform.LookAt(vec + transform.position);
        transform.Translate(vec * Time.deltaTime * moveSpeed, Space.World);
    }
}
