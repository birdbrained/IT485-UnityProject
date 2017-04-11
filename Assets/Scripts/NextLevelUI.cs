using UnityEngine;
using System.Collections;

public class NextLevelUI : MonoBehaviour 
{
    [SerializeField]
    private GameObject camera;
    private float rotationY;
    private AudioSource audio;

    // Use this for initialization
    void Awake () 
    {
        Debug.Log("Awake");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () 
    {
        rotationY = camera.transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(90, rotationY, 0);
    }

    void OnEnable()
    {
        Debug.Log("Enabled UI");
        if (audio != null)
        {
            Debug.Log("Playing Audio");
            audio.Play();
        }
    }
}
