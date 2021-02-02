using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    bool isStop = true;//标志位，来判断游戏是否需要被暂停
    public GameObject option;//这是我的设置UI界面
    // Update is called once per frame
    public void OnResume()//点击“继续游戏”时执行此方法
    {
        Time.timeScale = 1f;
        option.SetActive(false);
    }

    public void backtozhujiemian()//点击“主界面”时回到主界面
    {
        SceneManager.LoadScene("初始界面.game");
        Time.timeScale = 1f;
    }

    public void Restart()//点击“重新开始”时重新加载该关卡
    {
        SceneManager.LoadScene("第0关.game");
        Time.timeScale = 1f;
    }

    public void backtoguanqiaxuanze()//点击“关卡选择”时进入关卡选择界面
    {
        SceneManager.LoadScene("关卡选择界面.game");
        Time.timeScale = 1f;
    }


    void Update()
    {
        //游戏需要被暂停，按下ESC，游戏暂停，显示我的设置UI界面，然后将标志位设置成false，等待下次点击ESC启动游戏
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                option.SetActive(true);
            }
        }
        //游戏不需要被暂停，按下ESC，游戏启动，隐藏我的设置UI界面，然后将标志位设置成true，等待下次点击ESC暂停游戏
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                option.SetActive(false);
            }
        }
    }
}