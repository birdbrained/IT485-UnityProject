using UnityEngine;
using System.Collections;

public class ShootHitscan : MonoBehaviour 
{
    public Animator ani;
    public bool Firing { get; set; }
    private AudioSource audio;
    LineRenderer line;
    public bool FireTime;
    private bool CanDamageEnemy;
    private bool CanPlayAudio;

    //public float timer;
    //private float timerMax = 5.0f;
    public GameObject damageObj;

    // Use this for initialization
    void Start () 
    {
        ani = GetComponentInParent<Animator>();
        line = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
        line.enabled = false;
        FireTime = false;
        //timer = 0.0f;
        CanDamageEnemy = true;
        CanPlayAudio = true;
    }

    // Update is called once per frame
    void Update () 
    {
        /*Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            print("Something in front of object!");
        }*/

        //if (Input.GetButtonDown("Fire1"))
        if (FireTime)
        {
            //timer += Time.deltaTime;
            StopCoroutine(FireHitscan());

            if (CanPlayAudio)
            {
                audio.Play();
                CanPlayAudio = false;
            }

            StartCoroutine(FireHitscan());
            //FireTime = false;
        }
    }

    private IEnumerator FireHitscan()
    {
        line.enabled = true;

        //while (Input.GetButton("Fire1"))
        while(FireTime)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);                //Start position
            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.rigidbody && CanDamageEnemy)
                {
                    //hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);
                    Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.StartCoroutine(enemy.TakeDamage(20));
                        Instantiate(damageObj, enemy.transform.position, enemy.transform.rotation);
                        CanDamageEnemy = false;
                    }
                }
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));     //End position
            }

            //yield return null;
            yield return new WaitForSeconds(0.5f);
            FireTime = false;
            CanDamageEnemy = true;
            CanPlayAudio = true;
        }

        line.enabled = false;
        //GameManager.Instance.SpecialAmmo--;
    }
}
