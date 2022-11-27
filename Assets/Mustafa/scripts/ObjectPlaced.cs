using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlaced : MonoBehaviour
{
    public List<GameObject> grids;
    bool isPlaced;
    public LayerMask layer;
    RaycastHit hit;
    public BoxCollider gridsTrigs;
    GameObject gridSave;
    public bool isWall;
    public bool canSeal;
    private void OnTriggerEnter(Collider other)
    {
        if (isPlaced)
        {
            return;

        }
        if (gridsTrigs.size.x >= 1)
        {
            if (other.tag == "ground")
            {
                if (!isPlaced)
                {
                    other.GetComponent<grid>().gridColorOpen();
                    grids.Add(other.gameObject);
                }

            }
        }
        
    }
    private void OnDestroy()
    {
        
        for (int i = 0; i < grids.Count; i++)
        {
            grids[i].GetComponent<grid>().isOpend = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isPlaced)
        {
            return;

        }
        if (gridsTrigs.size.x >= 1)
        {
            if (other.tag == "ground")
            {
                if (!isPlaced)
                {
                    other.GetComponent<grid>().gridColorClose();
                    grids.Remove(other.gameObject);
                }
            }
        }
        
    }
    SphereCollider sphere;
    private void Update()
    {
        if (isPlaced)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Camera.main.transform.position,ray.direction, out hit, 1000, layer))
        {
            
            if (gridsTrigs.size.x < 1)
            {
                if (gridSave == null)
                {
                    gridSave = hit.transform.gameObject;
                    grids.Add(hit.transform.gameObject);
                    hit.transform.GetComponent<grid>().gridColorOpen();

                }
                if (gridSave!= hit.transform.gameObject)
                {
                    gridSave.GetComponent<grid>().gridColorClose();
                    hit.transform.GetComponent<grid>().gridColorOpen();
                    grids.Add(hit.transform.gameObject);
                    grids.Remove(gridSave);
                    gridSave = hit.transform.gameObject;
                }
                
            }

            transform.position = new Vector3(hit.point.x, 1, hit.point.z);
           
             if (Input.GetMouseButtonDown(0))
            {

                bool a = true;
                for (int i = 0; i < grids.Count; i++)
                {
                    if (grids[i].GetComponent<grid>().isOpend == false)
                    {
                        a = false;
                        break;
                    }

                }
                if ((gridsTrigs.size.x + 1) * (gridsTrigs.size.x + 1) != grids.Count)
                {
                    a = false;
                }
                if (a)
                {
                    Vector3 pos = Vector3.zero;
                    for (int i = 0; i < grids.Count; i++)
                    {
                        pos += grids[i].transform.position;
                    }
                    transform.position = new Vector3(pos.x / grids.Count, 1, pos.z / grids.Count);
                    for (int i = 0; i < grids.Count; i++)
                    {
                        grids[i].GetComponent<grid>().isOpend = false;
                        grids[i].GetComponent<grid>().material.color = Color.white;
                        isPlaced = true;
                    }
                       
                    Destroy(gridsTrigs);
                    Shop.instante.OpenPanel();

                    TryGetComponent<SphereCollider>(out sphere);
                    if (sphere != null)
                    {
                        sphere.enabled = true;

                    }

                    if (isWall)
                    {
                        if (Input.GetMouseButton(0)&&!GameManager.intance.waveIsContinious)
                        {
                            Shop.instante.buyWall();
                        }
                    }
                    else
                    {
                        Destroy(GetComponent<Rigidbody>());
                        AudioSource.PlayClipAtPoint(Shop.instante.clips[4], Vector3.zero);
                    }
                    canSeal = true;
                }
                
            }
            else if (isWall&& Input.GetMouseButton(0))
            {
                bool a = true;
                for (int i = 0; i < grids.Count; i++)
                {
                    if (grids[i].GetComponent<grid>().isOpend == false)
                    {
                        a = false;
                        break;
                    }

                }
                if ((gridsTrigs.size.x + 1) * (gridsTrigs.size.x + 1) != grids.Count)
                {
                    a = false;
                }
                if (a)
                {
                    Vector3 pos = Vector3.zero;
                    for (int i = 0; i < grids.Count; i++)
                    {
                        pos += grids[i].transform.position;
                    }
                    transform.position = new Vector3(pos.x / grids.Count, 1, pos.z / grids.Count);
                    for (int i = 0; i < grids.Count; i++)
                    {
                        grids[i].GetComponent<grid>().isOpend = false;
                        grids[i].GetComponent<grid>().material.color = Color.white;
                        isPlaced = true;
                    }

                    Destroy(gridsTrigs);
                    Shop.instante.OpenPanel();

                    if (Input.GetMouseButton(0) && !GameManager.intance.waveIsContinious)
                    {
                        Shop.instante.buyWall();
                    }
                    canSeal = true;
                    AudioSource.PlayClipAtPoint(Shop.instante.clips[5], Vector3.zero);
                }

            }
            else if(isWall)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Shop.instante.OpenPanel();
                    Destroy(gameObject);
                }
            }

        }
    }

}
