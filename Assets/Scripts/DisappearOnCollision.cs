using UnityEngine;
using System.Collections;

public class DisappearOnCollision : MonoBehaviour 
{
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("I hit a thing! Tag: " + other.tag);
        if (other.tag == "Player" || other.tag == "JuiceBox")
        {
            rend.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("A thing left! Tag: " + other.tag);
        if (other.tag == "Player" || other.tag == "JuiceBox")
        {
            rend.enabled = true;
        }
    }
}
