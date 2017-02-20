using UnityEngine;
using System.Collections;

public class Up : MonoBehaviour {

    private bool isRising;
    public float shootDistance;

	// Use this for initialization
	void Start () 
    {
        isRising = false;	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (isRising)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
	}

    public void AmIRising(bool b)
    {
        if (b)
        {
            isRising = true;
        }
        else
        {
            isRising = false;
        }
    }

    public void ShootUp()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + shootDistance, transform.position.z);
    }

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        AmIRising(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        AmIRising(false);
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnPointerExit.
    public void OnGazeTrigger()
    {
        ShootUp();
    }
}
