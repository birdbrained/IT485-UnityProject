using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour 
{
    private Animator animator;

    // Use this for initialization
    void Start () 
    {
        animator = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.S))
            animator.SetTrigger("down");
        if (Input.GetKeyDown(KeyCode.A))
            animator.SetTrigger("left");
        if (Input.GetKeyDown(KeyCode.W))
            animator.SetTrigger("up");
        if (Input.GetKeyDown(KeyCode.D))
            animator.SetTrigger("right");

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D))
            animator.SetTrigger("default");
    }
}
