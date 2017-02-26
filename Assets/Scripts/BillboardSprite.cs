using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour 
{
    // Update is called once per frame
    void FixedUpdate() 
    {
        transform.LookAt(Camera.main.transform.position, Camera.main.transform.up);
    }
}
