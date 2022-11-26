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
    

}
