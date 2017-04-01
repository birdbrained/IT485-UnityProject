using UnityEngine;
using System.Collections;

public class DonutProgressBar : MonoBehaviour 
{
    private Animator ani;

    void Start () 
    {
        ani = GetComponent<Animator>();
    }

    public void StartFilling()
    {
        //Only fill if the weapon is the lazer
        if (GameManager.Instance.CurrentWeapon == 3)
        {
            ani.SetTrigger("fill");
        }
    }

    public void StopFilling()
    {
        ani.SetTrigger("default");
    }


    //Shoot the lazer
    public void ShootLazer()
    {
        GameObject lazerShootPos = GameObject.FindGameObjectWithTag("LazerShootPos");
        ShootHitscan shoot = lazerShootPos.GetComponent<ShootHitscan>();
        shoot.FireTime = true;
        GameManager.Instance.SpecialAmmo--;
    }
}
