using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public GameObject target;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="enemy")
        {
            other.GetComponent<Enemy>().getDamage(damage);
        }
    }
    void Update()
    {
        if (target==null)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,0.1f);
    }
}
