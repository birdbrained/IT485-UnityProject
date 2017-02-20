using UnityEngine;
using System.Collections;

public class Up_WithoutGaze : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
    }
	
    // Update is called once per frame
    void FixedUpdate () 
    {
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }
}
