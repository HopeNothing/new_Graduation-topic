using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_floor : MonoBehaviour
{

    public string corece_name;

    public int corece_num;

    public int corece_num_max;

    public int corece_num_interval;

    public bool corece_stop;

    public SpriteRenderer sprite_imager;

    public Sprite[] sprite_number;

    public SpriteRenderer slider_imager;

    public Transform slider_tr;

    public float left_max;

    public float right_max;

    public bool hammer;

    private void Awake()
    {

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
        if (collision.GetComponent<prop_manger>().hammer ==true)
        {
            hammer = true;
        }
        else
        {
            hammer = false;
        }

            if ((corece_stop == true) && (hammer == false)) 
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

    void floor(string name)
    {
        if (corece_name == "")
        {
            corece_name = name;
            corece_num++;
        }
        else
        {
            if (corece_name == name)
            {
                corece_num++;
            }
            else
            {
                corece_num--;

                if (corece_num == 0)
                {
                    corece_name = "";
                    slider_imager.color = Color.white;
                    slider_tr.localPosition = new Vector3(left_max, slider_tr.localPosition.y, 0);
                }

            }
        }

        color();

    }

    void color()
    {
        if (corece_name == "")
        {
            slider_imager.color = Color.white;
        }
        else if (corece_name == "one")
        {
            slider_imager.color = Color.blue;

            if (corece_num / corece_num_interval == 0)
            {
                sprite_imager.sprite = sprite_number[0];
            }
            else if (corece_num / corece_num_interval == 1)
            {
                sprite_imager.sprite = sprite_number[1];
            }
            else if (corece_num / corece_num_interval == 2)
            {
                sprite_imager.sprite = sprite_number[2];
            }

            if (corece_num % corece_num_interval == 0)
            {
                slider_tr.localPosition = new Vector3(left_max, slider_tr.localPosition.y, 0);
            }
            else if (corece_num % corece_num_interval == 1)
            {
                slider_tr.localPosition = new Vector3(left_max / 3 * 2, slider_tr.localPosition.y, 0);
            }
            else if (corece_num % corece_num_interval == 2)
            {
                slider_tr.localPosition = new Vector3(left_max / 3, slider_tr.localPosition.y, 0);
            }

        }
        else if (corece_name == "two")
        {
            slider_imager.color = Color.red;

            if (corece_num / corece_num_interval == 0)
            {
                sprite_imager.sprite = sprite_number[0];
            }
            else if (corece_num / corece_num_interval == 1)
            {
                sprite_imager.sprite = sprite_number[1];
            }
            else if (corece_num / corece_num_interval == 2)
            {
                sprite_imager.sprite = sprite_number[2];
            }

            if (corece_num % corece_num_interval == 0)
            {
                slider_tr.localPosition = new Vector3(right_max, slider_tr.localPosition.y, 0);
            }
            else if (corece_num % corece_num_interval == 1)
            {
                slider_tr.localPosition = new Vector3(right_max / 3 * 2, slider_tr.localPosition.y, 0);
            }
            else if (corece_num % corece_num_interval == 2)
            {
                slider_tr.localPosition = new Vector3(right_max / 3, slider_tr.localPosition.y, 0);
            }
        }

        if(corece_num == corece_num_max)
        {
            corece_stop = true;
            slider_tr.localPosition = new Vector3(0, slider_tr.localPosition.y, 0);
        }
        //else if(corece_num == 0)
        //{
        //    slider_imager.color = Color.white;
        //    slider_tr .localPosition = new Vector3(left_max , slider_tr.localPosition.y, 0);
        //}
     




    }

    


}
