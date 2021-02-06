using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    public GameObject hideSpikeBox;
    public float time;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            StartCoroutine(SpikeAttack());
        }
    }

    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");
        Instantiate(hideSpikeBox, transform.position, Quaternion.identity);
    }
}