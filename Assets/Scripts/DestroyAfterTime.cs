using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public int lifetime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
