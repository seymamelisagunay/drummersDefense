using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerSys : MonoBehaviour
{
    GameObject enemy;
    RaycastHit hit;
    float ditanceRange;
    public float shootRange=11f;
    float time=2f;
    public int hpEnemy=3;
    int towerPower=1;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }


    private void Update()
    {

        if (Physics.Raycast(transform.position, enemy.transform.position,out hit))
        {
             
            ditanceRange = Vector3.Distance(transform.position, enemy.transform.position);
            Debug.DrawRay(transform.position, enemy.transform.position);
            if (ditanceRange <= shootRange)
            {
                //Debug.Log("distance: " + Vector3.Distance(transform.position, enemy.transform.position));
                //Debug.DrawRay(transform.position, enemy.transform.position,Color.red);//demage
                Debug.DrawRay(transform.position, enemy.transform.position,Color.yellow);//warning
                time -= Time.deltaTime;
                if (time<0)
                {
                    Debug.Log("demaged");
                    hpEnemy -= towerPower;
                    if (hpEnemy<=0)
                    {
                        Debug.Log("died");
                    }
                    
                    time = 2f;
                    
                     
                }

            }

 
        }




    }




}
