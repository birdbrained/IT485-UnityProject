using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour 
{
    [SerializeField]
    private float spinSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);
    }
	
}
