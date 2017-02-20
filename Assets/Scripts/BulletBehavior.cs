using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour 
{
    private Rigidbody rb;
    public float speed;
    //public float timeBeforeDestroy;
    [SerializeField]
    private GameObject damageObj;
    [SerializeField]
    private GameObject splishObj;
    private AudioSource shootSound;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //Destroy(gameObject, timeBeforeDestroy);
        shootSound = GetComponent<AudioSource>();
        shootSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = (GameObject)Instantiate(splishObj, gameObject.transform.position, gameObject.transform.rotation);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f, 3f), Random.Range(0f, 3f), Random.Range(0f, 3f));
        }
        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject, 0);
            //other.gameObject.SetActive(false);
            GameManager.Instance.Score++;
            Instantiate(damageObj, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

}
