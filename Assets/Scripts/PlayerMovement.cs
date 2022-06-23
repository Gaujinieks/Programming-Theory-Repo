using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float jumpVelocity = 100.0f;
    private Vector3 _inputs = Vector3.zero;
    public float nextToWall;
    BoxCollider _col;
    public PhysicMaterial slippery;


    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        _col = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        _inputs.x = Input.GetAxis("Horizontal");
        Jump(jumpVelocity);
        isAgainstWall();
    }

    public bool IsGrounded()//checking if we are on ground to know if we can jump
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
        }
    }

    private void isAgainstWall()// to change friction when player is against a wall so he doesnt stick to it.
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 5))// if player is on ground 
        {
            _col.material.dynamicFriction = 1;//there is friction
        }
        else 
        {
            _col.material.dynamicFriction = 0;//else we make friction = nothing
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputs.x > 0.1f || _inputs.x < -0.1f)
        {
            //rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * _inputs); // with this one it goes trough walls, don't know why
            rb.velocity = new Vector3(_inputs.x * speed, rb.velocity.y);
        }
    }

}
