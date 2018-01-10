using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
    {
    [Header ( "要生產的遊戲物件" )]
    public GameObject prefab;

    [Header ( "重力" )][Range ( -1 , 1 )]
    public float gravity;

    float lastSpawn;

    [Header ( "摩擦力" )][Range ( 0 , 10 )]
    public float prafabFriction;

    [Header ( "彈力" )][Range ( 0 , 1 )]
    public float prefabBounciness;

    [Header ( "多久生產一次(秒)" )]
    [Range ( 0 , 1 )]
    public float timeInterval;

    void Start ( )
        {
        lastSpawn = Time.time;
        }

    public void instantiateGameObjects ( GameObject prefab )
        {
        Rigidbody2D prefabRigibody2D = prefab.GetComponent<Rigidbody2D> ( );
        prefabRigibody2D.gravityScale = gravity;
        prefabRigibody2D.sharedMaterial.friction = prafabFriction;
        prefabRigibody2D.sharedMaterial.bounciness = prefabBounciness;

        if ( Time.time - lastSpawn >= timeInterval )
            {
            Instantiate ( prefab , transform.position , prefab.transform.rotation );
            lastSpawn = Time.time;
            }
        }

    void FixedUpdate ( )
        {
        instantiateGameObjects ( prefab );
        }

    }
