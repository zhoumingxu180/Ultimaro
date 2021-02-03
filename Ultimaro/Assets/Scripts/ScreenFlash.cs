using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image img;
    public float time;             //闪烁时间
    public Color FlashColor;       //闪烁颜色
    private Color defaultColor;     //默认颜色

    void Start()
    {
        defaultColor = img.color; 
    }

    
    void Update()
    {
        
    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        img.color = FlashColor;
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "UpCollider")                  //UpCollider是地刺上的碰撞检测
        {
            FlashScreen();                                  //碰到地刺扣血的同时屏幕红闪，可以加更多的if添加屏幕红闪的情况
        }

    }
}
