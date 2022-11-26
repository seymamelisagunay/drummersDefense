using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearTower : TowerAttack
{
    GameObject targetEnemy;
    public GameObject ammo;

    void Start()
    {
        StartCoroutine("fire");
    }


    void Update()
    {
        if (enemies.Count>0&& targetEnemy==null)
        {
            targetEnemy = enemies[0];
        }

    }

    IEnumerator fire ()
    {
        while (true)
        {
            if (targetEnemy!=null)
            {
                GameObject a = Instantiate(ammo,transform.position,Quaternion.identity);
                a.GetComponent<ammo>().target = targetEnemy;
                a.GetComponent<ammo>().damage = damage;
            }
            yield return new WaitForSeconds(coolDown);
        }
    }
}
