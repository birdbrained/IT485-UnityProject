using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour 
{
    private Rigidbody rb;
    public float speed;
    //public float timeBeforeDestroy;
    [SerializeField]
    private GameObject damageObj;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //Destroy(gameObject, timeBeforeDestroy);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
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
