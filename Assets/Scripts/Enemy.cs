using UnityEngine;
using System.Collections;
using System;

public class Enemy : Character 
{
    protected IEnemyStates currentState;
    [SerializeField]
    protected bool CanAnimate;
    public GameObject Target { get; set; }
    [SerializeField]
    protected float meleeRange;
    [SerializeField]
    protected float fireRange;

    [SerializeField]
    protected GameObject deathObj;
    protected bool canGiveScore = true;

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector3.Distance(transform.position, Target.transform.position) <= meleeRange;
            }
            return false;
        }
    }

    public bool InFireRange
    {
        get
        {
            if (Target != null)
            {
                return Vector3.Distance(transform.position, Target.transform.position) <= fireRange;
            }
            return false;
        }
    }

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

	// Use this for initialization
	void Start () 
    {
        base.Start();
        if (CanAnimate)
        {
            ChangeState(new IdleState());
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                if (CanAnimate)
                {
                    currentState.Execute();
                }
            }
            //LookAtTarget();
        }
        else
        {
            MyAnimator.SetTrigger("die");
        }
    }

    public void ChangeState(IEnemyStates newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage(int damage)
    {
        //Debug.Log("Damage: " + damage.ToString());
        health -= damage;
        if (!IsDead)
        {
            //Set animation trigger "damage" only if object can animate (ex: sprite)
            if (CanAnimate)
            {
                MyAnimator.SetTrigger("damage");
            }
        }
        else
        {
            if (CanAnimate)
            {
                MyAnimator.SetTrigger("die");
            }
            //gameObject.tag = "Corpse";
            Death();
            yield return null;
        }
    }

    IEnumerator Wait()
    {
        if (canGiveScore)
        {
            GameManager.Instance.Score++;
            canGiveScore = false;
        }
        yield return new WaitForSeconds(5);
        //GameManager.Instance.Score++;
        Destroy(gameObject);
    }

    public override void Death()
    {
        if (CanAnimate)
        {
            //Delay death to play animation
            MyCollider.isTrigger = false;
            MyRB.useGravity = true;
            StartCoroutine(Wait());
        }
        else
        {
            if (canGiveScore)
            {
                GameManager.Instance.Score++;
                canGiveScore = false;
            }
            if (deathObj != null)
            {
                Instantiate(deathObj, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
