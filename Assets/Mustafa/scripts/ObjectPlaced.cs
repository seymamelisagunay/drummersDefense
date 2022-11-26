using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlaced : MonoBehaviour
{
    public List<GameObject> grids;
    bool isPlaced;
    public LayerMask layer;
    RaycastHit hit;
    void Start()
    {
        Debug.Log(name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "ground")
        {
            other.GetComponent<grid>().gridColorOpen();
            grids.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            other.GetComponent<grid>().gridColorClose();
            grids.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        if (isPlaced)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Camera.main.transform.position,ray.direction, out hit, 1000, layer))
        {
            transform.position = new Vector3(hit.point.x, 1, hit.point.z);
            if (Input.GetMouseButtonDown(0))
            {
                bool a = true;
                for (int i = 0; i < grids.Count; i++)
                {
                    if (grids[i].GetComponent<grid>().isOpend==false)
                    {
                        a = false;
                        break;
                    }
                   
                }
                if (a)
                {
                    Vector3 pos=Vector3.zero;
                    for (int i = 0; i < grids.Count; i++)
                    {
                        grids[i].GetComponent<grid>().isOpend = false;
                        isPlaced = true;
                        pos += grids[i].transform.position;
                        Debug.Log(pos + " ///////" + grids[i].transform.position+"  /////"+grids.Count);

                    }
                    transform.position = new Vector3(pos.x / 4,1, pos.z / 4);
                }
            }
        }
    }

}
