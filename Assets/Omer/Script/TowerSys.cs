using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerSys : TowerAttack
{
    GameObject enemy;
    RaycastHit hit;
    float time=2f;
    public int hpEnemy=3;
    int towerPower=1;
    SphereCollider sphere;
     
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "enemy")
        {
            Destroy(enemy);
        }
    }



    //if (Physics.Raycast(transform.position, enemy.transform.position,out hit))
    //{

    //    ditanceRange = Vector3.Distance(transform.position, enemy.transform.position);
    //    Debug.DrawLine(transform.position, enemy.transform.position);
    //    Debug.DrawLine(transform.position, enemy.transform.position, Color.white);//warning
    //    if (ditanceRange <= shootRange)
    //    {
    //        //Debug.Log("distance: " + Vector3.Distance(transform.position, enemy.transform.position));
    //        //Debug.DrawRay(transform.position, enemy.transform.position,Color.red);//demage
    //        Debug.DrawLine(transform.position, enemy.transform.position,Color.yellow);//warning
    //        time -= Time.deltaTime;
    //        if (time<0)
    //        {
    //            Debug.Log("demaged");
    //            hpEnemy -= towerPower;
    //            if (hpEnemy<=0)
    //            {
    //                Debug.Log("died");
    //            }

    //            time = 2f;


    //        }

    //    }

}
