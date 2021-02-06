using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpikeBox : MonoBehaviour
{
    public float destroyTime;
    public int damage;

    

    void Start()
    {
        
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {

    }
}