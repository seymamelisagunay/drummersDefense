using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<int> MaxSpawnCount;
    public List<Vector2> Waves;
    public bool IsWaveStarted;
    private int spawnerCounter1;
    private int spawnerCounter2;
    [SerializeField] private float spawnPeriod = 2f;
    float total;
    int waveCount = 0;
    

    private void Start()
    {
        StartCoroutine("spawmObj");
    }
    void Update()
    {
        IsWaveStarted = GameManager.waveIsContinious;


 

    }

    IEnumerator spawmObj()
    {
        while (true)
        {
            if (IsWaveStarted)
            {
                if (total <= 0)
                {
                    total += Waves[waveCount].x;
                    total += Waves[waveCount].y;
                    GameManager.intance.kontrolcu = true;
                }
                if (spawnerCounter2 != Waves[waveCount].y)
                {
                    
                        Enemy2Spawner(Waves[waveCount].y);
                        total--;
                    
                }



                if (spawnerCounter1 != Waves[waveCount].x)
                {
                    
                        Enemy1Spawner(Waves[waveCount].x);
                        total--;
                    
                }
            }
            if (total <= 0)
            {
               
                GameManager.waveIsContinious = false;
                
                if (GameManager.intance.currentEnemies.Count <= 0&&GameManager.intance.kontrolcu)
                {
                    GameManager.intance.waveBreakTime = 30;
                    Shop.instante.OpenPanel();
                    GameManager.intance.spawmIsStoped = true;
                    GameManager.intance.kontrolcu = false;
                    waveCount++;
                    spawnerCounter2 = 0;
                    spawnerCounter1 = 0;
                    EventManager.WaveEndAction();

                }

            }
            yield return new WaitForSeconds(spawnPeriod);
        }
    }
    public void Enemy1Spawner(float x)
    {
        
        if (x>0)
        {
            GameObject a= Instantiate(Enemies[0]);
            GameManager.intance.currentEnemies.Add(a);
            spawnerCounter1++;
        }
       
    }
    public void Enemy2Spawner(float y)
    {
        
        if (y > 0)
        {
            GameObject a = Instantiate(Enemies[1]);
            GameManager.intance.currentEnemies.Add(a);
            spawnerCounter2++;
        }

    }
}
