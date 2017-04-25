using UnityEngine;
using System.Collections;

public class Squawk : MonoBehaviour 
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void SQUAWK()
    {
        audio.Play();
    }

}
