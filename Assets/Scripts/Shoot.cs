using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
    public GameObject shot;
    public Transform shotSpawn;
    public bool Firing { get; set; }
    public float fireRate;
    private float nextFire;
    private Animator ani;

    [SerializeField]
    private bool IsShotgun;
    [SerializeField]
    private bool IsSpecial;

    // Use this for initialization
    void Start () 
    {
        ani = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetButton("Fire1") && !Firing/*Time.time > nextFire*/)
        {
            nextFire = Time.time + fireRate;
            if (IsShotgun)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector3 startPos = shotSpawn.position;
                    Quaternion startRot = shotSpawn.rotation;
                    float rand1 = Random.Range(-0.1f, 0.1f);
                    float rand2 = Random.Range(-0.1f, 0.1f);
                    float rand3 = Random.Range(-0.1f, 0.1f);
                    startPos.x += rand1;
                    startPos.y += rand2;
                    startPos.x += rand3;
                    startRot.x += rand1;
                    startRot.y += rand2;
                    startRot.z += rand3;
                    Instantiate(shot, startPos, startRot);
                }
                GameManager.Instance.SpecialAmmo--;
            }
            else if (IsSpecial)
            {
                Vector3 startPos = shotSpawn.position;
                Quaternion startRot = shotSpawn.rotation;
                Instantiate(shot, startPos, startRot);
                GameManager.Instance.SpecialAmmo--;
            }
            else
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            ani.SetTrigger("shoot");
        }
    }

    void OnEnable()
    {
        Firing = false;
    }
}
