using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem : MonoBehaviour
{

    Vector2 nor;
    Vector3 move;
    Rigidbody rb;
    public float speed=5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

 

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal");float ver = Input.GetAxis("Vertical");
        nor = new Vector2(hor, ver);
        move = new Vector3(nor.x, 0, nor.y).normalized* speed;
        rb.velocity = move;
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }

    }
}
