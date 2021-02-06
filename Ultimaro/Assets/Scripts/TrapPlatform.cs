using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private BoxCollider2D bx2D;
    private Animator anim;

    void Start()
    {
        bx2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Collapse");
        }
    }

    void DisableBoxCollider()
    {
        bx2D.enabled = false;
    }

    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}