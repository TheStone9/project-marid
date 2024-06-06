using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump_no_phys : MonoBehaviour
{
    public float jumpForce = 300f;
    private Rigidbody rb;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded= true;
    }
}
