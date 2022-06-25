using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerUpController : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();
    private AudioSource soundEffect;
    public GameManager gameManager;


    public Vector3 PosOffset// just to learn getters and setters.
    {
        get { return posOffset; }
        set { posOffset = value; }
    }

    public AudioSource SoundEffect
    {
        get { return soundEffect; }
        set { soundEffect = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundEffect = GetComponent<AudioSource>();
        PosOffset = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpRotation();//To rotate power ups
        PowerUpFloating(amplitude, frequency);// to make power ups float
    }

    public virtual void PowerUpRotation()
    {
        transform.Rotate(new Vector3(0, 0.15f, 0));
    }

    public void PowerUpFloating(float hight, float recurrence)
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime* Mathf.PI* recurrence) * hight;
        transform.position = tempPos;
    }

    public virtual void OnCollisionEnter(Collision collision)//play sound then disable renderer and collision body, then destroy.
    {
        SoundEffect.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1f);
        gameManager.coinAmount++;
    }
}
