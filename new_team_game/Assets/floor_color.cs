using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_color : MonoBehaviour
{
    public int number = 0;

    public string name;

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
        if (name == "")
        {
            name = name_void;
            number++;
        }
        else
        {
            if (name == name_void)
            {
                number++;
            }
            else
            {
                number--;

                if (number == 0)
                {
                    name = "";
                }

            }
        }

        if(name == "")
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            number = 0;
        }
       else  if (name == "one")
        {
            if (number == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3, 255);
            }
            if (number == 2)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 255 / 3 * 2, 255);
            }
            if (number == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        else if (name == "two")
        {
            if (number == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3, 0, 0, 255);
            }
            if (number == 2)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255 / 3 * 2, 0, 0, 255);
            }
            if (number == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

    }

}
