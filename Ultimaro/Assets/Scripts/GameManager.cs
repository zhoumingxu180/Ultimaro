using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


// 自己定义的类，可以根据需求加入想要存储的变量，我只用了position，注意数据类型。
public class GameSaving {
    public string sceneName;
    public Vector3 position;
    public float[] rotation;
    public string goldnumber;
}


public class GameManager : MonoBehaviour {

    private Scene scene;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get{return _instance;}
    }

    private float f_dis = 0;
    private int dis = 0;
    private int bonus = 0;

    private Text goldText;
    private Text distanceText;
    private GameObject go;
    

    private Rigidbody2D player;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        goldText = GameObject.Find("GoldText").GetComponent<Text>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        // bgT = GameObject.Find("Grounds").GetComponent<BackgroundTranform>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        go = GameObject.Find("GameOver");

        go.SetActive(false);

        scene = SceneManager.GetActiveScene(); //判断获取当前在哪个场景
    }
	
	// Update is called once per frame
	void Update () {
        UpdateDistance();

        //如果跑动距离大于400米，算通关，后续会加通关动画（待改）
        if (dis >= 400)
        {
            SceneManager.LoadScene("通关界面.game");
        }
	}

    private void UpdateDistance()
    {
        f_dis += player.velocity.x * Time.deltaTime;
        dis = (int)f_dis;
        
        distanceText.text = dis.ToString();
    }

    public void GameOver()
    {
        Debug.Log("sadsad");
        // GameObject[] bg = GameObject.FindGameObjectsWithTag("Background");
        // foreach (GameObject i in bg)
        // {
        //     Debug.Log(i);
        //     i.GetComponent<BackgroundTranform>().enabled = false;
        // }

        // 创建变量，存取数据
        GameSaving gameSaving = new GameSaving();
        // gameSaving.position = new float[3];
        // 在目前的场景中寻找Tag为Player的游戏物体列表，由于Player只有一个，所以列表中第一个就是，所以[0]，然后读取这个游戏物体的Component，也就是tranform，并读取里面的position
        //gameSaving.position = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;

        gameSaving.goldnumber = GameObject.Find("GoldText").GetComponent<Text>().text;

        // 讲类转换为Json数据格式
        string jsonData = JsonUtility.ToJson (gameSaving, true);
        // 显示一下到底存在哪里
        Debug.Log(Application.persistentDataPath + "/saveload.json");
        // 讲Json表示的数据写入到硬盘
        File.WriteAllText(Application.persistentDataPath + "/saveload.json", jsonData);

        GameObject.Find("Player").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player").GetComponent<CharacterController2D>().enabled = false;
        this.enabled = false;
        go.SetActive(true);
    }

    public void UpdateBonus(int count)
    {
        bonus += count;
        goldText.text = bonus.ToString();

    }

    public void RestartClick()
    {
        SceneManager.LoadScene(scene.name);
        go.SetActive(false);
    }

    public void ExitClick()
    {
        Application.LoadLevel(1);
    }
}
