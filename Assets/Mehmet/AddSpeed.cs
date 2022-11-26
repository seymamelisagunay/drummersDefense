using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{
     
    public float speed;
    public bool xBool;
    public bool yBool;
    public bool zBool;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (xBool) { transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);}
        if (yBool) { transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);}
        if (zBool) { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);}
    }
}
