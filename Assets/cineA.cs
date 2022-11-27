using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cineA : MonoBehaviour
{

    public float DistanceToPlayer;
    public float baseDistanceToPlayer;
    public Transform TargetTransform;
    public float zoomSensitivity;
    Transform camTran;
    public float minSize;
    public float maxSize;
    float fov;

    public float speed;
    void Start()
    {
        //camTran.position = new Vector3(0f, 60f, -13.2f);
        baseDistanceToPlayer = Vector3.Distance(transform.position, TargetTransform.position);
        transform.position = new Vector3();

    }
    public void CamZoom()
    {
        fov = Camera.main.orthographicSize;

        fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minSize, maxSize);
        Camera.main.orthographicSize = fov;
    }
 
    void LateUpdate()
    {



        CamZoom();

 
        transform.position = Vector3.Lerp(transform.position, InitPos(), 0.05f);
 
        transform.position = Vector3.Lerp(transform.position, CalculatePos(), 0.05f);
    }


    private Vector3 CalculatePos()
    {
        var pos = transform.position;

        var direction = transform.forward * -1;

        pos = TargetTransform.position + direction.normalized * fov;

        return pos;
    }

    private Vector3 InitPos()
    {
        var pos = transform.position;

        var direction = transform.forward * -1;

        pos = TargetTransform.position + direction.normalized * fov;

        return pos;
    }

    private void Update()
    {
        
    }
}
