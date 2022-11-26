using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{

    public float coolDown;
    float timer;
    public float damage;
    public float range;
    public float cost;
    public float ditanceRange;
    public float shootRange;
    public List<Enemy> enemies;
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
