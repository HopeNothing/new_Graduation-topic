using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class player_conter : MonoBehaviour
{
    public enum player_number { one, two }

    public player_number player_num;

    public enum player { go_left, go_right }

    public player player_direction;

    public enum player_animation { none, walk, jump_up, jump_down }

    public player_animation player_dragon_animation;

    public player_animation player_dragon_animation_last;

    public bool animation_is_play;

    public UnityArmatureComponent player_doagon;

    public float jump_speed;

    public float speed;

    public Rigidbody2D player_rigidbody;

    public bool onground;

    //public bool jump_bool;



    private void Awake()
    {
        player_rigidbody = this.GetComponent<Rigidbody2D>();

        

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<CapsuleCollider2D>(), GameObject.FindGameObjectWithTag("player").GetComponent<CapsuleCollider2D>());
    }

    // Use this for initialization
    void Start()
    {
        //player_dragon_animation = player_animation.walk;
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
        //dragon_animation();

        //if(jump_bool ==true)
        //{
        //    jump_animaion();
        //}
        player_static();
    }

    private void move()
    {
        if (player_direction == player.go_left)
        {
            player_rigidbody.velocity = new Vector2(-speed * Time.deltaTime , player_rigidbody.velocity.y);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player_direction == player.go_right)
        {
            player_rigidbody.velocity = new Vector2(speed * Time.deltaTime, player_rigidbody.velocity.y);
            this.transform.localScale = new Vector3(-1, 1, 1);
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
                    //jump_bool = true;
                    //player_dragon_animation = player_animation.jump_up;
                }
            }
            else
            {
                //print("左");

                if ((player_num == player_number.two) && (onground == true))
                {
                    player_rigidbody.velocity += new Vector2(0, jump_speed);
                    onground = false;
                    //jump_bool = true;
                    //player_dragon_animation = player_animation.jump_up;
                }
            }
        }


    }

    void player_static()
    {
        if(onground == true)
        {
            player_dragon_animation = player_animation.walk;
            if(player_dragon_animation != player_dragon_animation_last)
            {
                player_dragon_animation_last = player_dragon_animation;
                //animation_is_play = true;
                dragon_animation(player_dragon_animation.ToString());
            }
            else
            {
                return;
            }
        }

        if ((onground == false) &&(player_rigidbody.velocity.y > 0))
        {
            player_dragon_animation = player_animation.jump_up;
            if (player_dragon_animation != player_dragon_animation_last)
            {
                player_dragon_animation_last = player_dragon_animation;
                //animation_is_play = true;
                dragon_animation(player_dragon_animation.ToString());
            }
            else
            {
                return;
            }
        }

        if ((onground == false) && (player_rigidbody.velocity.y < 0))
        {
            player_dragon_animation = player_animation.jump_down;
            if (player_dragon_animation != player_dragon_animation_last)
            {
                player_dragon_animation_last = player_dragon_animation;
                //animation_is_play = true;
                dragon_animation(player_dragon_animation.ToString());
            }
            else
            {
                return;
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

    void dragon_animation(string name)
    {
        //print(player_doagon.animationName);
        //if ((onground == true) && (player_doagon.animationName != "walk"))
        //{
        //    player_doagon.animation.GotoAndPlayByTime("walk", 0, 0);
        //}
        //else
        //{
        //    if ((player_rigidbody.velocity.y > 0) && (onground == false))
        //    {
        //        player_doagon.animation.GotoAndPlayByTime("jump_up", 0, 1);
        //    }
        //    else if ((player_rigidbody.velocity.y < 0) && (onground == false))
        //    {
        //        player_doagon.animation.GotoAndPlayByTime("jump_down", 0, 1);
        //    }
        //}

        //if (player_dragon_animation == player_animation.walk)
        //{
        //    player_doagon.animation.GotoAndPlayByTime("walk", 0, 0);
        //    player_dragon_animation = player_animation.none;
        //}

        //if (player_dragon_animation == player_animation.jump_up)
        //{
        //    player_doagon.animation.GotoAndPlayByTime("jump_up", 0, 1);
        //    player_dragon_animation = player_animation.none;
        //}

        //if (player_dragon_animation == player_animation.jump_down)
        //{
        //    player_doagon.animation.GotoAndPlayByTime("jump_down", 0, 1);
        //    player_dragon_animation = player_animation.none;
        //}

        if(name == "walk")
        {
            player_doagon.animation.GotoAndPlayByTime("walk", 0, 0);
        }

        if (name == "jump_up")
        {
            player_doagon.animation.GotoAndPlayByTime("jump_up", 0, 1);
        }

        if (name == "jump_down")
        {
            player_doagon.animation.GotoAndPlayByTime("jump_down", 0, 1);
        }

        //player_doagon.animationName = aaa;
        //print(player_doagon.animationName);
    }

    //void jump_animaion()
    //{

    //}

    //public string aaa;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    print(collision.gameObject.name + collision.gameObject.transform.parent.name);
    //}

    public void change_direction()
    {
        if(player_direction == player.go_left)
        {
            player_direction = player.go_right;
        }
        else
        {
            player_direction = player.go_left;
        }
    }

}
