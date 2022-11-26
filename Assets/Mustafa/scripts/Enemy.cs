using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent ai;
    private NavMeshPath path;
    RaycastHit hit;
    public LayerMask layer;
    public float coolDown;
    float timer;
    public float damage;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        ai = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    private void OnDestroy()
    {
        GameManager.intance.currentEnemies.Remove(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ai.destination = target.transform.position;
        if (!ai.pathPending)
        {
            
        }
        else
        {
            
            if (Physics.Raycast(transform.position, target.transform.position - transform.position, out hit, 1000, layer))
            {
                if (hit.transform.tag=="wall"|| hit.transform.tag =="tower")
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, 0.01f);
                    if (Vector3.Distance(transform.position,hit.point)<2)
                    {
                        if (timer>coolDown)
                        {
                            hit.transform.GetComponent<ObjeHeal>().getDamage(damage);
                            timer = 0;

                        }
                    }

                }
                else
                {
                    Debug.LogError("i cant stay");
                }
            }
            
        }
        
        
    }
}
