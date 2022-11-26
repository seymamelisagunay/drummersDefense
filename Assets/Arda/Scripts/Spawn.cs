using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<int> MaxSpawnCount;
    public List<Vector2> Waves;
    public int waveId;
    public bool IsWaveStarted;
    private float nextSpawnTime = 0;
    private float nextSpawnTime1 = 0;
    private int spawnerCounter1;
    private int spawnerCounter2;
    [SerializeField] private float spawnPeriod = 2f;


    void Update()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            if (IsWaveStarted)
            {
                if (spawnerCounter2 != Waves[i].y)
                {
                    if (Time.time >= nextSpawnTime)
                    {
                        nextSpawnTime = Time.time + spawnPeriod;
                        Enemy2Spawner(Waves[i].y);
                    }
                }



                if (spawnerCounter1 !=Waves[i].x)
                {
                    if (Time.time >= nextSpawnTime1)
                    {
                        nextSpawnTime1 = Time.time + spawnPeriod;
                        Enemy1Spawner(Waves[i].x);
                    }
                }
            }

        }     

    }

    public void Enemy1Spawner(float x)
    {
        if (x>0)
        {
            Instantiate(Enemies[0]);
            spawnerCounter1++;
        }
       
    }
    public void Enemy2Spawner(float y)
    {
        if (y > 0)
        {
            Instantiate(Enemies[1]);
            spawnerCounter2++;
        }

    }
}
