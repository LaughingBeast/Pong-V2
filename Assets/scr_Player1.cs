using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scr_Player : MonoBehaviour
{
    public scr_GameLogic GameLogic;
    public Rigidbody2D PlayerRB;

    bool Player1PointCap;
    bool Player2PointCap;

    public bool Player2;
    public float Speed;
    public int Score;

    [Header("Text")]
    public TMP_Text ScoreTextP1;
    public TMP_Text ScoreTextP2;

    public List<GameObject> WallIn; 


    private void Start()
    {
        Player1PointCap = false;
        Player2PointCap = false;

       for (int i = 0; i < WallIn.Count; i++)
        {
            WallIn[i].SetActive(false);
        }



        if (transform.position.x > 0)
        {
            Player2 = true;
        } else
        {
            Player2 = false;
        }

    }

    void Update()
    {
        if ( Score == GameLogic.RNumberPlusPoint && gameObject.transform.position.x < 0 && Player1PointCap == false)
        {
             
            GameLogic.Player1PointCap = true;
            Player1PointCap = true;
        } else if (Score == GameLogic.RNumberPlusPoint && gameObject.transform.position.x > 0 && Player2PointCap == false) 
        {
            GameLogic.Player2PointCap = true;
            Player2PointCap = true;
        }

        


        if (!Player2)
         {

            if (Input.GetKey(KeyCode.A))
            {
                PlayerRB.transform.position += (Vector3.left * Speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                PlayerRB.transform.position += (Vector3.right * Speed) * Time.deltaTime;
            }
        } else
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerRB.transform.position += (Vector3.left * Speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                PlayerRB.transform.position += (Vector3.right * Speed) * Time.deltaTime;
            }
        }
    }


   
}
