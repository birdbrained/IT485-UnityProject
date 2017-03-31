using UnityEngine;
using System.Collections;

public class ShootHitscan : MonoBehaviour 
{
    LineRenderer line;

    // Use this for initialization
    void Start () 
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update () 
    {
        /*Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            print("Something in front of object!");
        }*/

        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine(FireHitscan());
            StartCoroutine(FireHitscan());
        }
    }

    private IEnumerator FireHitscan()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);                //Start position
            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                //Debug.Log(hit.transform.gameObject.name);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);
                }
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));     //End position
            }

            yield return null;
        }

        line.enabled = false;
    }
}
