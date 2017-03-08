using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : Character
{

	// Use this for initialization
	void Start () 
    {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        health -= 10;
        if (IsDead)
        {
            Death();
            yield return null;
        }
    }

    public override void Death()
    {
        health = 30;
        SceneManager.LoadScene("GameOver");
    }
}
