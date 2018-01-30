using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_id : MonoBehaviour {

    public enum ID { permanent,once }
    [Header("常駐或一次")]
    public ID id;
    [Header("(必填)道具名稱")]
    public string prop_name;
    [Header("(必填)道具")]
    public GameObject prop_object;
    [Header("(常駐用)常駐時間")]
    public float prop_time;
    [Header("(一次用)UI圖片")]
    public Sprite UI_sprite;

}
