using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_color : MonoBehaviour
{
    public int number = 0;

    public string name_num;

    public SpriteRenderer floor_render;

    public Sprite[] floor_number;

    public bool stop;

    private void Awake()
    {
        floor_render = this.transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(stop ==true)
        {
            return;
        }
        
        if ((collision.GetComponent<player_conter>().player_num == player_conter.player_number.one) && (collision.GetComponent<player_conter>().onground == true))
        {
            //this.GetComponent<SpriteRenderer>().color = Color.blue;
            floor(collision.GetComponent<player_conter>().player_num.ToString());
        }
        else if ((collision.GetComponent<player_conter>().player_num == player_conter.player_number.two) && (collision.GetComponent<player_conter>().onground == true))
        {
            //this.GetComponent<SpriteRenderer>().color = Color.red;
            floor(collision.GetComponent<player_conter>().player_num.ToString());

        }
    }

    void floor(string name_void)
    {
        if (name_num == "")
        {
            name_num = name_void;
            number++;
        }
        else
        {
            if (name_num == name_void)
            {
                number++;
            }
            else
            {
                number--;

                if (number == 0)
                {
                    name_num = "";
                }

            }
        }

        if (name_num == "")
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            number = 0;
        }
        else if (name_num == "one")
        {
            if (number == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3, 255);
                floor_render.sprite = floor_number[0];
            }
            if (number == 2)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3 * 2, 255);
                floor_render.sprite = floor_number[0];
            }
            if (number == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                floor_render.sprite = floor_number[0];
            }
            if (number == 4)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3, 255);
                floor_render.sprite = floor_number[1];
            }
            if (number == 5)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3 * 2, 255);
                floor_render.sprite = floor_number[1];
            }
            if (number == 6)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                floor_render.sprite = floor_number[1];
            }
            if (number == 7)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3, 255);
                floor_render.sprite = floor_number[2];
            }
            if (number == 8)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3 * 2, 255);
                floor_render.sprite = floor_number[2];
            }
            if (number == 9)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                floor_render.sprite = floor_number[2];
                stop = true;
            }
        }
        else if (name_num == "two")
        {
            if (number == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3, 0, 0, 255);
                floor_render.sprite = floor_number[0];
            }
            if (number == 2)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3 * 2,0, 0,  255);
                floor_render.sprite = floor_number[0];
            }
            if (number == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                floor_render.sprite = floor_number[0];
            }
            if (number == 4)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3, 0, 0, 255);
                floor_render.sprite = floor_number[1];
            }
            if (number == 5)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3 * 2, 0, 0, 255);
                floor_render.sprite = floor_number[1];
            }
            if (number == 6)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                floor_render.sprite = floor_number[1];
            }
            if (number == 7)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3, 0, 0, 255);
                floor_render.sprite = floor_number[2];
            }
            if (number == 8)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3 * 2, 0, 0, 255);
                floor_render.sprite = floor_number[2];
            }
            if (number == 9)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                floor_render.sprite = floor_number[2];
                stop = true;
            }

        }

    }

}
