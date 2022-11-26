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
        ai.destination = target.transform.position;
        if (!ai.pathPending)
        {
            
        }
        else
        {
            
            if (Physics.Raycast(transform.position, target.transform.position - transform.position, out hit, 1000))
            {
                if (hit.transform.tag=="wall"|| hit.transform.tag =="tower")
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, 0.01f);

                }
            }
            
        }
        
        
    }
}
