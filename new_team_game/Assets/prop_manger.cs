using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_manger : MonoBehaviour {

    //public LayerMask layer;

    public bool hammer;

    public GameObject hand;

    public GameObject hammer_game;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == layer)
    //    {
    //        switch (collision.gameObject.tag)
    //        {
    //            case "hammer":
    //                hammer = true;
    //                Destroy(collision.gameObject);
    //                GameObject.Instantiate(hammer_game, hand.transform);
    //                break;
    //            default:
    //                print("Error : collision.gameObject.tag");
    //                break;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer ==  LayerMask.NameToLayer("prop"))
        {
            switch (collision.gameObject.tag)
            {
                case "hammer":
                    hammer = true;
                    Destroy(collision.gameObject);
                    GameObject.Instantiate(hammer_game,hand.transform);
                    break;
                default:
                    print("Error : collision.gameObject.tag");
                    break;
            }
        }
    }

}
