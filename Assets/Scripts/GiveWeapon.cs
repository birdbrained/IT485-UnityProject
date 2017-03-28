using UnityEngine;
using System.Collections;

public class GiveWeapon : MonoBehaviour 
{
    [SerializeField]
    private GameObject powerupSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GivePlayerWeapon(string weaponName)
    {
        GameObject player = GameObject.Find("Player");
        PlayerController pc = (PlayerController)player.GetComponent(typeof(PlayerController));
        pc.PickupWeapon(weaponName);

        Instantiate(powerupSound, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
    }
}
