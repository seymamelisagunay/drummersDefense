using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : TowerAttack
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=coolDown)
        {
            GameObject[] eneiesArray = enemies.ToArray();
            for (int i = 0; i < eneiesArray.Length; i++)
            {
                eneiesArray[i].GetComponent<Enemy>().getDamage(damage);
            }
            timer = 0;
        }
    }
}
