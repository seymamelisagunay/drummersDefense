using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public static float money;
    public float Vmoney;
    public float waveBreakTime;
    public bool spawmIsStoped=false;

    public static bool waveIsContinious;
    public bool kontrolcu;
    [HideInInspector]public float timer;
    public List<GameObject> currentEnemies;
    void Start()
    {
        money = Vmoney;
        waveIsContinious = true;
        kontrolcu = true;   
        intance = this;
    }
    private void Update()
    {
        
        if (spawmIsStoped)
        {
            timer += Time.deltaTime;
            if (timer >= waveBreakTime)
            {
                waveIsContinious = true;
                spawmIsStoped=false;
                Shop.instante.onPresCreat = false;
                Shop.instante.closePanel();
                timer = 0;

            }
        }
            
        
       
    }
}
