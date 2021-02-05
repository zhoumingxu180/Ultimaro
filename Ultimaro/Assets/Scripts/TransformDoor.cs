using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDoor : MonoBehaviour
{
    public Transform backDoor;

    private bool isDoor;
    private Transform playerTransform;

    

    void Awake()
    {
        
    }

   

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            )
        {
            //Debug.Log("触碰到门了");
            isDoor = true;
            playerTransform.position = backDoor.position;
        }
    }

    
}