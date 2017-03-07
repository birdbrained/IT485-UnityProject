using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private Animator ani;

    // Use this for initialization
    void Start () 
    {
        ani = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            ani.SetTrigger("shoot");
        }
    }
}
