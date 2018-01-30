using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class prop_manger : MonoBehaviour
{

    //public LayerMask layer;
    [Header("常駐用------------------")]
    [Header("常駐啟動")]
    public bool prop_permanent_on;
    [Header("常駐道具名")]
    public string prop_permanent_ID;
    [Header("常駐GameObject")]
    public GameObject prop_permanent_gameObject;
    [Header("常駐道具時間")]
    public float time;
    [Header("一次性用------------------")]
    [Header("一次性UI")]
    public Image UI_image;
    [Header("一次性道具名")]
    public string prop_once_ID;
    [Header("一次性GameObject")]
    public GameObject prop_once_gameObject;
    [Header("一次性道具輸出位置")]
    public Transform prop_emission;

    //public bool hammer;

    //public GameObject hand;

    //public GameObject hammer_game;


    [Header("道具位置")]
    public Transform hammer_prop_transform;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (prop_permanent_on == true)
        {
            permanent_prop_time();
        }

     

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
        if (collision.gameObject.layer == LayerMask.NameToLayer("prop"))
        {
            //switch (collision.gameObject.tag)
            //{
            //    case "hammer":
            //        //hammer = true;
            //        //Destroy(collision.gameObject);
            //        //GameObject.Instantiate(hammer_game,hand.transform);
            //        break;
            //    default:
            //        print("Error : collision.gameObject.tag");
            //        break;
            //}

            prop_id prop = collision.GetComponent<prop_id>();

            if (prop.id.ToString() == "permanent")
            {
                //permanent_prop(collision.GetComponent<prop_id>().prop_name.ToString());
                
                permanent_prop(prop.prop_name.ToString(), prop.prop_object, prop.prop_time);
            }
            else if (prop.id.ToString() == "once")
            {
                once_prop(prop.prop_name.ToString(),prop.prop_object,prop.UI_sprite);
            }
            print(collision.gameObject.name);

            //collision.gameObject.SetActive(false);

        }
    }

    void permanent_prop(string id_name, GameObject prop,float prop_time_set)
    {
        if (prop_permanent_on == true)
        {
            Destroy(prop_permanent_gameObject);
            prop_permanent_on = false;
            prop_permanent_ID = "";
        }

        switch (id_name)
        {
            case "hammer":
                GameObject ins = GameObject.Instantiate(prop, hammer_prop_transform);
                //if(this.gameObject.GetComponent<player_conter>().player_num.ToString() == "two")
                //{
                //    Vector3 new_vec3 = ins.transform.rotation.eulerAngles;
                //    new_vec3.z *= -1;
                //    ins.transform.rotation = Quaternion.Euler(new_vec3);
                //}
                time = prop_time_set;
                prop_permanent_gameObject = ins;
                prop_permanent_on = true;
                prop_permanent_ID = "hammer";
                break;
            default:
                print("Error :" + id_name);
                break;
        }
    }

    void once_prop(string id_name, GameObject prop,Sprite ui_spriter)
    {
        //switch (id_name)
        //{
        //    case "bonb":
        //        UI_image.sprite = ui_spriter;
        //        prop_once_ID = id_name;
        //        prop_once_gameObject = prop;
        //        break;
        //    default:
        //        print("Error :" + id_name);
        //        break;
        //}

        UI_image.sprite = ui_spriter;
        prop_once_ID = id_name;
        prop_once_gameObject = prop;
    }

    //void permanent_prop_set(float prop_time)
    //{

    //}

    void permanent_prop_time()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
            prop_permanent_on = false;
            prop_permanent_ID = "";
            Destroy(prop_permanent_gameObject);
        }
    }

    public void button_prop_on()
    {
        switch (prop_once_ID)
        {
            case "bonb":
                prop_bonb_on();
                break;
            default:
                print("Error :" + prop_once_ID);
                break;
        }

        UI_image.sprite = null;
        prop_once_ID = "";
        prop_once_gameObject = null;

    }

    void prop_bonb_on()
    {
        if (this.GetComponent<player_conter>().player_direction.ToString() == "go_left")
        {
            GameObject ins = GameObject.Instantiate(prop_once_gameObject, prop_emission.position, Quaternion.identity);
            ins.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1000, 500, 0));
        }
        else if (this.GetComponent<player_conter>().player_direction.ToString() == "go_right")
        {
            GameObject ins = GameObject.Instantiate(prop_once_gameObject, prop_emission.position, Quaternion.identity);
            ins.GetComponent<Rigidbody2D>().AddForce(new Vector3(1000, 500, 0));
        }
    }

}
