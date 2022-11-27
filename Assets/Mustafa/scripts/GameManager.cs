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

    public bool waveIsContinious;
    public bool kontrolcu;
    public float timer;
    public List<GameObject> currentEnemies;

    public int totalSapawm;
    public int waveCount;
    public GameObject[] spwaners;

    private void Awake()
    {
        money = Vmoney;
        waveIsContinious = true;
        kontrolcu = true;
        intance = this;
    }
    void Start()
    {
        spwaners = GameObject.FindGameObjectsWithTag("spawner");
    }
    private void Update()
    {
        
        if (spawmIsStoped)// false kalýyor
        {
            timer += Time.deltaTime;
            if (timer >= waveBreakTime)
            {
                waveIsContinious = true; //*****
                for (int i = 0; i < spwaners.Length; i++)
                {
                    spwaners[i].GetComponent<Spawn>().sýfýrlama();
                }
                spawmIsStoped=false;
                Shop.instante.onPresCreat = false;
                Shop.instante.closePanel();
                timer = 0;
                AudioSource.PlayClipAtPoint(Shop.instante.clips[2], Vector3.zero);

            }
        }

        if (totalSapawm <= 0 && kontrolcu)
        {
            waveIsContinious = false;

            if (currentEnemies.Count <= 0)
            {
                waveBreakTime = 30;
                Shop.instante.OpenPanel();   
                waveCount++;               
                EventManager.WaveEndAction();
                spawmIsStoped = true;
                AudioSource.PlayClipAtPoint(Shop.instante.clips[3], Vector3.zero);
                kontrolcu = false;

            }

        }

    }
}
