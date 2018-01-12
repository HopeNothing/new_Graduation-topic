using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_conter : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 10);
        }

    }
}
