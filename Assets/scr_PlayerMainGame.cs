using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class scr_PlayerMainGame : MonoBehaviour
{
    public Rigidbody2D PlayerRB;

    public float Speed;
    
    bool Player1 = true; 


    void Start()
    {
        if (gameObject.transform.position.x > 0 ) 
        {
            Player1 = false;
        } else { Player1 = true; }

        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    { 
        

        if (!Player1)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                PlayerRB.transform.position += (Vector3.up * Speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                PlayerRB.transform.position += (Vector3.down * Speed) * Time.deltaTime;
            }
        } 
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                PlayerRB.transform.position += (Vector3.up * Speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                PlayerRB.transform.position += (Vector3.down * Speed) * Time.deltaTime;
            }
        }
    }
}
