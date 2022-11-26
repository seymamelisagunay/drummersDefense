using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public bool isOpend =true;
    Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        EventManager.showGrid += gridColorOpen;
        material.color = Color.white ;
    }
    private void OnDestroy()
    {
        EventManager.showGrid -= gridColorOpen;
    }

    public void gridColorOpen()
    {
        if (isOpend)
        {
            material.color = Color.green;
        }
        else
        {
            material.color = Color.red;
        }
    }
    public void gridColorClose()
    {
        material.color = Color.white;
    }
}
