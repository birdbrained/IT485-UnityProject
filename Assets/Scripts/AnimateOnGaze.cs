using UnityEngine;
using System.Collections;

public class AnimateOnGaze : MonoBehaviour 
{

    public void GazeAnimation(bool gazed)
    {
        gameObject.GetComponent<Animator>().SetBool("gazedAt", gazed);
    }

}
