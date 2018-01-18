using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    public enum tower_arrow { left, right }

    public tower_arrow tower_direction;

    public GameObject arrow;

    // Use this for initialization
    void Start()
    {
        if (tower_direction == tower_arrow.left)
        {
            arrow.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            arrow.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<player_conter>().player_direction == player_conter.player.go_left) && (tower_direction == tower_arrow.right))
        {
            collision.gameObject.GetComponent<player_conter>().change_direction();
            tower_direction = tower_arrow.left;
            arrow.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if ((collision.gameObject.GetComponent<player_conter>().player_direction == player_conter.player.go_right) && (tower_direction == tower_arrow.left))
        {
            collision.gameObject.GetComponent<player_conter>().change_direction();
            tower_direction = tower_arrow.right;
            arrow.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
