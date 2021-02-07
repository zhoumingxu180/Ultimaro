using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public float speed;
    public float FlyDistance;

    private Rigidbody2D rg2d;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        rg2d.velocity = transform.right * (-speed);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (startPos - transform.position).sqrMagnitude;
        if (distance > FlyDistance)
        {
            Destroy(gameObject);
        }
    }
}
