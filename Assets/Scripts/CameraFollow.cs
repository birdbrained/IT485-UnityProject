using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField]
    private GameObject camera;
    private float rotationY;
    private Animator animator;

    // Use this for initialization
    void Start () 
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        rotationY = camera.transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(90, rotationY, 0);

        if (camera.transform.localEulerAngles.x > 40.0f && !animator.GetBool("visible"))
        {
            animator.SetBool("visible", true);
        }

        if (camera.transform.localEulerAngles.x < 40.0f && animator.GetBool("visible"))
        {
            animator.SetBool("visible", false);
        }
    }
}
