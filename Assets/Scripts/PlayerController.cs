using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : Character
{
    private AudioSource hurtSound;
    private bool immortal = false;
    [SerializeField]
    private float immortalTime;
    [SerializeField]
    private GameObject juicebox;

	// Use this for initialization
	void Start () 
    {
        base.Start();
        hurtSound = GetComponent<AudioSource>();
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

    private IEnumerator IndicateImmortality()
    {
        while (immortal)
        {
            //juicebox.GetComponent<MeshRenderer>().enabled = false;
            foreach (Transform child in juicebox.transform)
            {
                if (child.name != "ShootPos")
                    child.GetComponent<MeshRenderer>().enabled = false;
            }
            //juicebox.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            //juicebox.GetComponent<MeshRenderer>().enabled = true;
            foreach (Transform child in juicebox.transform)
            {
                if (child.name != "ShootPos")
                    child.GetComponent<MeshRenderer>().enabled = true;
            }
            //juicebox.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override IEnumerator TakeDamage()
    {
        if (!immortal)
        {
            health -= 10;
            hurtSound.Play();
            if (!IsDead)
            {
                immortal = true;
                StartCoroutine(IndicateImmortality());
                yield return new WaitForSeconds(immortalTime);
                immortal = false;
            }
            else
            {
                Death();
                yield return null;
            }
        }
    }

    public override void Death()
    {
        health = 30;
        SceneManager.LoadScene("GameOver");
    }
}
