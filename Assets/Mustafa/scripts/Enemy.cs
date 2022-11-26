using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent ai;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        ai = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.destination = target.transform.position;
    }
}
