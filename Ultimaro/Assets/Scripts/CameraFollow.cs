using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    

    // Start is called before the first frame update
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
                targetPos.x = targetPos.x + 4;
                targetPos.y = targetPos.y - 0.5f;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    
}