using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHammerStart : MonoBehaviour
{
    public GameObject GroundHammerPrefab;
    public float TrrigerDistance;

    private Transform playerTransform;
    private Vector3 GroundHammerStartPos;
    

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GroundHammerStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (GroundHammerStartPos.x - playerTransform.position.x);
        if (distance < TrrigerDistance)
        {
            Instantiate(GroundHammerPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
