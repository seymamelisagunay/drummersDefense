using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeHeal : MonoBehaviour
{
    public float heal;
    [HideInInspector]public float baseHeal;
    void Start()
    {
        baseHeal = heal;
        EventManager.WaveEnd += ToweReset;
    }
    private void OnDestroy()
    {
        EventManager.WaveEnd -= ToweReset;
    }
    private void ToweReset()
    {
        heal = baseHeal;
    }

    public void getDamage(float a)
    {
        heal -= a;
        if (heal<=0)
        {
            Destroy(gameObject);
        }
    }
 
}
