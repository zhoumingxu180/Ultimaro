using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(camera.GetComponent<Camera>().pixelRect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
