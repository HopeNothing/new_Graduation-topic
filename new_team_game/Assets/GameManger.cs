using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

    //將腳本轉型為靜態腳本
    private static GameManger _instance;

    public static GameManger instance
    {
        get
        {
            return _instance;
        }
    }


    public BoxCollider2D upWall;
    public BoxCollider2D downWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D leftWall;

    public Transform point_1;
    public Transform point_2;
    public Transform boss;

    void Awake()
    {
        _instance = this;
    }


    // Use this for initialization
    void Start()
    {
        ResetWall();
    }

    // Update is called once per frame
    void Update()
    {
        //print(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)));
    }

    void ResetWall()
    {
        upWall = GameObject.Find("up").GetComponent<BoxCollider2D>();
        downWall = GameObject.Find("down").GetComponent<BoxCollider2D>();
        rightWall = GameObject.Find("right").GetComponent<BoxCollider2D>();
        leftWall = GameObject.Find("left").GetComponent<BoxCollider2D>();
        //取得BoxCollider2D

        Vector3 tempPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //計算攝影機的寬和高，並將他轉成世界座標
        //意思為 Screen.width, Screen.height 場景寬高 換成世界座標 
        //換算後為 攝影機 右上角 為 Vector3


        upWall.transform.position = new Vector3(0, tempPosition.y + 0.5f, 0);
        upWall.size = new Vector2(tempPosition.x * 2, 1);
        //將位置改變到攝影機外框，並改變大小

        downWall.transform.position = new Vector3(0, -tempPosition.y - 0.5f, 0);
        downWall.size = new Vector2(tempPosition.x * 2, 1);

        rightWall.transform.position = new Vector3(tempPosition.x + 0.5f, 0, 0);
        rightWall.size = new Vector2(1, tempPosition.y * 2);

        leftWall.transform.position = new Vector3(-tempPosition.x - 0.5f, 0, 0);
        leftWall.size = new Vector2(1, tempPosition.y * 2);

        point_1.transform.position = new Vector2(0 - tempPosition.x * 0.8f, 0);
        point_2.transform.position = new Vector2(0 + tempPosition.x * 0.8f, 0);
        boss.transform.position = new Vector2(0, tempPosition.y * 0.8f);
    }
}
