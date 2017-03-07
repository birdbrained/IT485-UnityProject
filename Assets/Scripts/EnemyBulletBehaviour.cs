using UnityEngine;
using System.Collections;

public class EnemyBulletBehaviour : MonoBehaviour 
{
    private Rigidbody rb;
    public float speed;
    private Vector3 direction;
    //public float timeBeforeDestroy;
    [SerializeField]
    private GameObject splishObj;
    //private AudioSource shootSound;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.localPosition, Camera.main.transform.up);
        //rb.velocity = transform.forward * speed;
        //shootSound = GetComponent<AudioSource>();
        //shootSound.Play();
    }
	
    void FixedUpdate () 
    {
        rb.velocity = transform.forward * speed;
    }

    public void Initialize(Vector3 dir)
    {
        direction = dir;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = (GameObject)Instantiate(splishObj, gameObject.transform.position, gameObject.transform.rotation);
                obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f, 3f), Random.Range(0f, 3f), Random.Range(0f, 3f));
            }
            Destroy(gameObject);
        }
    }
}
