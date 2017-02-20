using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour 
{
    [SerializeField]
    protected List<string> damageSources = new List<string>();
    [SerializeField]
    protected int health;
    public abstract bool IsDead { get; }
    public bool TakingDamage { get; set; }

    // Use this for initialization
    public virtual void Start () 
    {
        
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
