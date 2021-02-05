using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkPlayer : MonoBehaviour
{
    private Renderer myRender;
    public int blinks;                        //闪烁次数
    public float time;                        //单次闪烁时间
   
    void Start()
    {
        myRender = GetComponent<Renderer>();
    }

    
    void Update()
    {
        
    }

    public void Blink (int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i=0; i<numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "UpCollider")                  //UpCollider是地刺上的碰撞检测
        {
            Blink(blinks, time);                                  //碰到地刺扣血的同时人物闪烁，可以加更多的if添加人物闪烁的情况
        }
         
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "EnemyBarrier")
        {
            Blink(blinks, time);

        }
    }
}
