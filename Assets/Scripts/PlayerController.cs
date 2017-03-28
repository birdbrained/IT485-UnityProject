using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : Character
{
    private AudioSource hurtSound;
    private bool immortal = false;
    [SerializeField]
    private float immortalTime;
    //[SerializeField]
    //private GameObject juicebox;
    [SerializeField]
    private GameObject[] weapons;

    public static int specialAmmo;
    public Text ammoText;

	// Use this for initialization
	void Start () 
    {
        base.Start();
        hurtSound = GetComponent<AudioSource>();
        specialAmmo = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (specialAmmo == 0 && !Attacking)
        {
            PickupWeapon("Juicebox");
        }
        if (ammoText != null)
        {
            if (specialAmmo > 0)
            {
                ammoText.text = "x" + specialAmmo.ToString();
            }
            else
            {
                ammoText.text = "";
            }
        }
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
            foreach (GameObject juicebox in weapons)
            {
                foreach (Transform child in juicebox.transform)
                {
                    if (child.name != "ShootPos")
                        child.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            //juicebox.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            //juicebox.GetComponent<MeshRenderer>().enabled = true;
            foreach (GameObject juicebox in weapons)
            {
                foreach (Transform child in juicebox.transform)
                {
                    if (child.name != "ShootPos")
                        child.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            //juicebox.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override IEnumerator TakeDamage(int damage)
    {
        if (!immortal)
        {
            health -= damage;
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

    public void PickupWeapon(string weaponName)
    {
        if (weaponName == "JuiceShotgun")
        {
            if (!weapons[1].gameObject.activeSelf)
            {
                foreach (GameObject juicebox in weapons)
                {
                    juicebox.SetActive(false);
                }
            }
            weapons[1].SetActive(true);
            specialAmmo = 10;
        }
        else if (weaponName == "Juicebox")
        {
            if (!weapons[0].gameObject.activeSelf)
            {
                foreach (GameObject juicebox in weapons)
                {
                    juicebox.SetActive(false);
                }
            }
            weapons[0].SetActive(true);
            specialAmmo = 0;
        }
    }
}
