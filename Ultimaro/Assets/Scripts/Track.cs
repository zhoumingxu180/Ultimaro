using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Player";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 2;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<ParticleSystem>().shape.radius = 0.5f;
        var shape = GetComponent<ParticleSystem>().shape;
        var emission = GetComponent<ParticleSystem>().emission;
        GetComponent<ParticleSystem>().startLifetime = player.velocity.x / 14f;
        emission.rateOverTime = player.velocity.x * 2;
        // GetComponent<ParticleSystem>().shape.scale = new Vector3(2f, 1f, 1f);
        // Debug.Log(player.velocity.x / 11f);
        shape.radius = player.velocity.x / 11f;
    }
}
