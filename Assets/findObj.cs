using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findObj : MonoBehaviour
{
    public TowerAttack parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            parent.enemies.Add(other.gameObject);
            other.transform.GetComponent<Enemy>().TowerAttackTriggers.Add(parent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            parent.enemies.Remove(other.gameObject);
            other.transform.GetComponent<Enemy>().TowerAttackTriggers.Remove(parent);
        }
    }
}
