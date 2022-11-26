using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YapayZeka : MonoBehaviour
{
    private NavMeshAgent yapayZeka;

    void Start()
    {
        yapayZeka = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            RaycastHit hit;
            Ray tiklamaRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(tiklamaRay, out hit))
            {
                    
                yapayZeka.destination = hit.point;
            }
        }
    }
}
