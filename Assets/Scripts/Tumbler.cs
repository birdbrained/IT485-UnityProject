using UnityEngine;
using System.Collections;

public class Tumbler : MonoBehaviour 
{
    private Rigidbody rb;
    public float tumblr;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        Tumble();
    }

    void Tumble()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumblr;
    }
}
