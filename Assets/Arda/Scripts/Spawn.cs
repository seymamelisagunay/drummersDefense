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
    int waveCount = 0;
    

    private void Start()
    {
        sýfýrlama();
        StartCoroutine("spawmObj");
       
    }
    void Update()
    {
        IsWaveStarted = GameManager.intance.waveIsContinious;
       waveCount = GameManager.intance.waveCount;

        Debug.Log("spawnerCounter1 " + spawnerCounter1 + "  spawnerCounter2  " + spawnerCounter2);
        
    }
    public void sýfýrlama ()
    {
        spawnerCounter2 = 0;
        spawnerCounter1 = 0;
        GameManager.intance.totalSapawm = (int)Waves[waveCount].x + (int)Waves[waveCount].y + GameManager.intance.totalSapawm;
        GameManager.intance.kontrolcu = true;
    }

    IEnumerator spawmObj()
    {
        while (true)
        {
            Debug.Log(name+" "+ IsWaveStarted);
            if (IsWaveStarted)
            {
                
                if (spawnerCounter2 != Waves[waveCount].y)
                {
                    
                  Enemy2Spawner(Waves[waveCount].y);
                  GameManager.intance.totalSapawm-=1;
                    
                }
                yield return new WaitForSeconds(spawnPeriod/2);


                if (spawnerCounter1 != Waves[waveCount].x)
                {
                    
                  Enemy1Spawner(Waves[waveCount].x);
                  GameManager.intance.totalSapawm -= 1;
                    
                }
            }
            
            yield return new WaitForSeconds(spawnPeriod/2);
        }
    }
    public void Enemy1Spawner(float x)
    {
        
        if (x>0)
        {
            GameObject a= Instantiate(Enemies[0],transform.position,Quaternion.identity);
            GameManager.intance.currentEnemies.Add(a);
            spawnerCounter1++;
        }
       
    }
    public void Enemy2Spawner(float y)
    {
        
        if (y > 0)
        {
            GameObject a = Instantiate(Enemies[1],transform.position, Quaternion.identity);
            GameManager.intance.currentEnemies.Add(a);
            spawnerCounter2++;
        }

    }
}
