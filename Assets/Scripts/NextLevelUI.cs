using UnityEngine;
using System.Collections;

public class NextLevelUI : MonoBehaviour 
{
    [SerializeField]
    private GameObject camera;
    private float rotationY;

    // Use this for initialization
    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update () 
    {
        rotationY = camera.transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(90, rotationY, 0);
    }
}
