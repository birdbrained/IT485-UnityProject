using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour 
{
    private Rigidbody rb;
    private Animator ani;
    public float speed;
    [SerializeField]
    private GameObject explosionObj;

    private bool exploding = false;

    //private AudioSource shootSound;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        rb.velocity = transform.forward * speed;
        //shootSound = GetComponent<AudioSource>();
        //shootSound.Play();
        StartCoroutine(Explodinate());
    }

    private Vector3 growVector = new Vector3(0.15f, 0.15f, 0.15f);
    // Update is called once per frame
    void Update()
    {
        if (exploding)
        {
            transform.localScale += growVector;
            /*Color c = transform.GetComponent<Renderer>().material.color;
            if (c.a > 0f)
            {
                c.a -= 0.1f;
                transform.GetComponent<Renderer>().material.color = c;
            }
            else
            {
                Destroy(gameObject);
            }*/
        }
    }

    private IEnumerator Explodinate()
    {
        yield return new WaitForSeconds(3f);
        exploding = true;
        ani.SetTrigger("fade");
        Instantiate(explosionObj, gameObject.transform.position, new Quaternion(0f, 90f, 0f, 0f));
    }

    public void DeleteMyself()
    {
        Destroy(gameObject);
    }
}
