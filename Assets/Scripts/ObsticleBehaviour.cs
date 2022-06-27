using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE >>
public class ObsticleBehaviour : PowerUpController // override collision and rotation.
{
    private bool stopObstacle = false;
    // Start is called before the first frame update
    void Start()
    {
        // ENCAPSULATION >>
        SoundEffect = GetComponent<AudioSource>();
        PosOffset = transform.position;
        // ENCAPSULATION <<
    }
    // Update is called once per frame
    void Update()
    {
        PowerUpRotation();

        if (!stopObstacle)
        {
            PowerUpFloating(amplitude, frequency);
        }
    }

    // POLYMORPHISM >>
    public override void PowerUpRotation()
    {
        transform.Rotate(new Vector3(-0.15f, 0, 0));// make it rotate around x axis instead of y axis and in different direction
    }

    public override void OnCollisionEnter(Collision collision)
    {
        SoundEffect.Play();
        Destroy(collision.gameObject);// destroy player instead of other object
        stopObstacle = true;
    }
    // POLYMORPHISM <<
}
