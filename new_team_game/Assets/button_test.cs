using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_test : MonoBehaviour {

    [SerializeField]
    Button button = null;

    void Awake()
    {
        this.button.onClick.AddListener(this.OnButtonClicked);
    }

    void OnDestroy()
    {
        this.button.onClick.RemoveListener(this.OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // TODO: 處理事件
        print("aaa");
    }
}
