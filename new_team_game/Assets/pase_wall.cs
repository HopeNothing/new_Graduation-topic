using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pase_wall : MonoBehaviour {

    public GameObject pase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.name + this.gameObject.name);

        collision.gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x, pase.transform.position.y);

    }
}
