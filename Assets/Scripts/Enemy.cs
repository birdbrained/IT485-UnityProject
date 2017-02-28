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
            //Here would go the code to set an animation trigger "damage"
            if (CanAnimate)
            {
                MyAnimator.SetTrigger("damage");
            }
        }
        else
        {
            //ani trigger "die"
            //gameObject.tag = "Corpse";
            Death();
            yield return null;
        }
    }

    public override void Death()
    {
        Destroy(gameObject);
    }
}
