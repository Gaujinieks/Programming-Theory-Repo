using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleBehaviour : PowerUpController // override collision and rotation.
{
    // Start is called before the first frame update
    void Start()
    {
        PosOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpRotation();
        PowerUpFloating(amplitude, frequency);
    }

    public override void PowerUpRotation()
    {
        transform.Rotate(new Vector3(-0.15f, 0, 0));// make it rotate around x axis instead of y axis and in different direction
    }

    public override void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);// destroy player instead of other object
    }



}
