using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 500;
    public float jumpVelocity = 100.0f;
    private Vector3 _inputs = Vector3.zero;
    //private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    //void OnCollisionStay()
    //{
    //    isGrounded = true;
    //    Debug.Log(isGrounded);
    //}

    private void Update()
    {
        _inputs.x = Input.GetAxis("Horizontal");
        Jump(jumpVelocity);
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 5))
        {
            return true;
        }
        else
            return false;
    }

    public void Jump(float velocity)
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector3.up * velocity;
            //isGrounded = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputs.x > 0.1f || _inputs.x < -0.1f)
        {
            rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * _inputs);
        }
    }

}
