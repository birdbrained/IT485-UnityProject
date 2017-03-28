using UnityEngine;
using System.Collections;

public class AreaOfEffectDamage : MonoBehaviour 
{
    public float explosionRadius;
    public int explosionDamage;
    public GameObject damageObj;

    // Use this for initialization
    void Start () 
    {
        AreaDamageEnemies(gameObject.transform.position, explosionRadius, explosionDamage);
    }
	
    // Update is called once per frame
    void Update () 
    {
        
    }

    void AreaDamageEnemies(Vector3 location, float radius, int damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider c in objectsInRange)
        {
            Enemy enemy = c.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.StartCoroutine(enemy.TakeDamage(damage));
                enemy.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
                Instantiate(damageObj, enemy.transform.position, enemy.transform.rotation);
            }
        }
    }
}
