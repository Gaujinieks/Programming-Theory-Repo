using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTileController : MonoBehaviour
{
    public float destroyTimer;
    public virtual void OnCollisionEnter(Collision collision)// destroy platform after few seconds
    {
        Destroy(gameObject, destroyTimer);
    }
}
