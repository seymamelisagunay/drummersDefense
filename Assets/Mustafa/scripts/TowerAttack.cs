using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{

    public float coolDown;
    [HideInInspector] public float timer;
    public float damage;
    public float range;
    public float cost;
    public List<GameObject> enemies;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="enemy")
        {
            enemies.Add(other.gameObject);
            other.transform.GetComponent<Enemy>().TowerAttackTriggers.Add(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemies.Remove(other.gameObject);
            other.transform.GetComponent<Enemy>().TowerAttackTriggers.Remove(this);
        }
    }

}
