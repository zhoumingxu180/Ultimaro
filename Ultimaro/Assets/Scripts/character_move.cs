using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Speed = animator.GetFloat("Speed");
        // AnimatorControllerParameter[] parameters = animator.parameters;
        // Debug.Log("sadasd "+parameters[0].name);
        // Debug.Log(Speed);
        // float Speed = 
    }
}
