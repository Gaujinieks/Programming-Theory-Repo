using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 500;
    public float jumpVelocity = 100.0f;
    private Vector3 _inputs = Vector3.zero;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        _inputs.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Space was pressed");
            rb.velocity = Vector3.up * jumpVelocity;
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputs.x > 0.1f || _inputs.x < -0.1f)
        {
            rb.MovePosition(rb.position + _inputs * speed * Time.fixedDeltaTime);
        }
    }

}
