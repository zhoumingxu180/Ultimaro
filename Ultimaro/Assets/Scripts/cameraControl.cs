using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x+3, transform.position.y, transform.position.z);
    }
}
