using UnityEngine;

public class CameraController : MonoBehaviour
//public class 攝影機控制器 : MonoBehaviour
    {
    [Header ( "玩家物件" )]
    public GameObject Player;

    [Header ( "相對位移" )]
    public Vector3 offset;//相對位移 宣告成public可以即時修改數值

    void Start ( )
    //void 開始() 遊戲開始時執行一次
        {
        offset = transform.position - Player.transform.position;
        //相對位移 = 攝影機的變形.座標 - 玩家.變形.座標
        }

    void FixedUpdate ( )
    //void 固定時間間隔更新() 預設固定每0.02秒執行一次 所以每秒執行50次 通常將物理運動相關的程式放在這裡
        {
        transform.position = Player.transform.position + offset;
        // 攝影機的變形.座標 = 玩家.變形.座標 + 相對位移)

        }
    }
