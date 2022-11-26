using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSys : MonoBehaviour
{
    GameObject enemy;
    public float VecValue = 0.01f;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
 

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, enemy.transform.position, VecValue);
        
    }
}
