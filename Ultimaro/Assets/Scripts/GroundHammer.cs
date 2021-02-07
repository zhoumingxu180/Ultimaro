using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHammer : MonoBehaviour
{
    public float speed;
    

    private Rigidbody2D rg2d;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        rg2d.velocity = transform.up * (-speed);
        startPos = transform.position;

    }   
    void Update()
    {
        
    }

   
    
}
