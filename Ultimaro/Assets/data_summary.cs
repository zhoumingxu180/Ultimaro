using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;



public class data_summary : MonoBehaviour
{
    private Text goldnumber2;
    private Text goldnumber3;

    void Start()
    {

        // 读取存储在硬盘上的json文件。
        GameSaving gameSaving = JsonUtility.FromJson<GameSaving>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        // 取得里面的数据
        goldnumber2 = GameObject.Find("Text1").GetComponent<Text>();
        goldnumber3 = GameObject.Find("Text2").GetComponent<Text>();
        goldnumber2.text = gameSaving.goldnumber;
        goldnumber3.text = gameSaving.goldnumber;
        Debug.Log(gameSaving.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
