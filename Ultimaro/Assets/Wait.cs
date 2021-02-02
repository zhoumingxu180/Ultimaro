using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    public float wait_time = 5f;

    void Start()
    {
        StartCoroutine(wait_for_intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait_for_intro()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(1);
    }
}
