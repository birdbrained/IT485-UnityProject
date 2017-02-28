using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour 
{
    protected IEnemyStates currentState;
    [SerializeField]
    protected List<string> damageSources = new List<string>();
    [SerializeField]
    protected int health;
    public abstract bool IsDead { get; }
    public bool TakingDamage { get; set; }
    public Animator MyAnimator { get; private set; }
    public Collider MyCollider { get; private set; }
    public Rigidbody MyRB { get; private set; }

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

    public abstract IEnumerator TakeDamage();
    public abstract void Death();

    public virtual void OnTriggerEnter(Collider other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }
}
