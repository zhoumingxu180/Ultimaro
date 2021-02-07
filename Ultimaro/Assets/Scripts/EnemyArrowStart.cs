using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowStart : MonoBehaviour
{
    public GameObject EnemyArrowPrefab;
    public float TrrigerDistance;

    private Transform playerTransform;
    private Vector3 EnemyArrowStartPos;
    private bool p = true;
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyArrowStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (EnemyArrowStartPos - playerTransform.position ).sqrMagnitude;
        if (distance < TrrigerDistance)
        {
            Instantiate(EnemyArrowPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
