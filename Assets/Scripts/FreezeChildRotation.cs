using UnityEngine;
using System.Collections;

public class FreezeChildRotation : MonoBehaviour 
{
    private Quaternion myRotation;

    void Awake()
    {
        myRotation = gameObject.transform.rotation;
    }

    void LateUpdate()
    {
        gameObject.transform.rotation = myRotation;
    }
}
