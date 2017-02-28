using UnityEngine;
using System.Collections;
using System;

public class Enemy : Character 
{
    [SerializeField]
    protected bool CanAnimate;

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
	}
	
	// Update is called once per frame
	/*void Update () 
    {
        if (!IsDead)
        {
            if (!TakingDamage)
            {
                //implement currentState here
            }
        }
    }*/

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        health -= 10;
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
        yield return new WaitForSeconds(5);
        GameManager.Instance.Score++;
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
            GameManager.Instance.Score++;
            Destroy(gameObject);
        }
    }
}
