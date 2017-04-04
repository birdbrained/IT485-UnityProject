using UnityEngine;
using System.Collections;

public class EnableObjOnDeath : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] objects;
    //[SerializeField]
    //private Vector3 spawnPos;
    [SerializeField]
    private GameObject[] disabledObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDisable()
    {
        OnDestroy();
    }

    void OnDestroy()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
        if (disabledObjects.Length > 0)
        {
            foreach (GameObject obj in disabledObjects)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
