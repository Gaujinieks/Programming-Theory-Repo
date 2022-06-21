using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    Rigidbody powerUpRB;
    // Start is called before the first frame update
    void Start()
    {
        powerUpRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.15f, 0));//To rotate power ups
    }
}
