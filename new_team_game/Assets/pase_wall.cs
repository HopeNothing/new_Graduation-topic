using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pase_wall : MonoBehaviour {

    public GameObject pase;

    public bool up_down;

    public bool left_right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.name + this.gameObject.name);

        if(((up_down==false)&&(left_right == false))|| ((up_down == true) && (left_right == true)))
        {
            print("Error : 牆壁錯誤");
            return;
        }

        if(up_down == true)
        {
            collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x, pase.transform.position.y);
        }
        else if(left_right == true)
        {
            collision.gameObject.transform.position = new Vector2(pase.transform.position.x,collision.gameObject.transform.position.y);
        }
        

    }
}
