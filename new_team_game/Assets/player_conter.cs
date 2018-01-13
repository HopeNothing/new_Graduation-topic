using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_conter : MonoBehaviour
{
    public enum player_number { one, two }

    public player_number player_num;

    public enum player { go_left, go_right }

    public player player_direction;

    public float jump_speed;

    public float speed;

    public Rigidbody2D player_rigidbody;

    public bool onground;

    private void Awake()
    {
        player_rigidbody = this.GetComponent<Rigidbody2D>();

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("player").GetComponent<BoxCollider2D>());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.GetComponent<Rigidbody2D>().velocity.y);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    //this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 10);
        //    this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_speed));
        //}

        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.GetComponent<Rigidbody2D>().velocity.y);
        move();
    }

    private void move()
    {
        if (player_direction == player.go_left)
        {
            player_rigidbody.velocity = new Vector2(-speed * Time.deltaTime , player_rigidbody.velocity.y);
        }
        else if (player_direction == player.go_right)
        {
            player_rigidbody.velocity = new Vector2(speed * Time.deltaTime, player_rigidbody.velocity.y);
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].position.x > (Screen.width / 2))
            {
                //print("右");
                if ((player_num == player_number.one) &&(onground ==true))
                {
                    player_rigidbody.velocity += new Vector2(0, jump_speed);
                    onground = false;
                }
            }
            else
            {
                //print("左");

                if ((player_num == player_number.two) && (onground == true))
                {
                    player_rigidbody.velocity += new Vector2(0, jump_speed);
                    onground = false;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "floor") && (player_rigidbody.velocity.y <= 0))
        {
            onground = true;
        }
    }

}
