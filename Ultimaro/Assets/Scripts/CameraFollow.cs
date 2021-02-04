using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    

    
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
               
                transform.position =new Vector3(Vector3.Lerp(transform.position, targetPos, smoothing).x, transform.position.y, transform.position.z);
            }
        }
    }

   
}