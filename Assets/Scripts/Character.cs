using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour 
{
    [SerializeField]
    protected Transform ShootPos;
    [SerializeField]
    protected GameObject ShootPrefab;
    
    [SerializeField]
    protected List<string> damageSources = new List<string>();
    [SerializeField]
    protected int health;
    public abstract bool IsDead { get; }
    public bool TakingDamage { get; set; }
    public bool Attacking { get; set; }
    public Animator MyAnimator { get; private set; }
    public Collider MyCollider { get; private set; }
    public Rigidbody MyRB { get; private set; }

    public bool hasARangedAttack;
    public bool hasAMeleeAttack;

    // Use this for initialization
    public virtual void Start () 
    {
        MyAnimator = GetComponent<Animator>();
        MyCollider = GetComponent<Collider>();
        MyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () 
    {
        
    }

    public abstract IEnumerator TakeDamage(int damage);
    public abstract void Death();

    public virtual void FireBullet()
    {
        GameObject tmp = (GameObject)Instantiate(ShootPrefab, ShootPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        if (tag == "Player" || tag == "JuiceBox")
        {
            //add stuff here
        }
        else
        {
            tmp.GetComponent<EnemyBulletBehaviour>().Initialize(GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition);
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (damageSources.Contains(other.tag))
        {
            int damage = 0;
            if (other.name.Contains("Juice_Apple"))
            {
                damage = 5;
            }
            else if (other.name.Contains("Juice"))
            {
                damage = 10;
            }
            StartCoroutine(TakeDamage(damage));
        }
    }
}
