using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scr_ball : MonoBehaviour
{
    public GameObject Player;
    private scr_Player _playerScript;

    public Rigidbody2D RB;

    public scr_MainGameLogic MGLogic;

    bool PreGameStart = false;
    bool GameInProgres = false;
    

    public float Speed = 3;
    float _startTimer;
   
    
    float x;
    float y;
    


    void Start()
    {
        _startTimer = 1;
        GameInProgres = false;
       
       
       _playerScript = Player.GetComponent<scr_Player>();
       
        
    }

    private void Update()
    {
        if (_startTimer > 0)
        {
            _startTimer -= Time.deltaTime;
            
        }
        if (_startTimer <= 0)
        {
            PreGameStart = true;
            
        }

        if (PreGameStart == true  && GameInProgres == false)
        {
            
            x = Random.Range(0, 2) == 0 ? -1 : 1;
            y = Random.Range(0, 2) == 0 ? -1 : 1;
            RB.linearVelocity = new Vector2(Speed * x, Speed * y);
            GameInProgres = true;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            scr_GameLogic.BallCount--;
            Destroy(gameObject);
           
        }

        if (collision.gameObject.layer == 10)
        {
            float rn = Random.value;
            int i;
            if (_playerScript.Player2 == true)
            {
                if (rn > 0.5)
                {
                    i = 3;
                }
                else { i = 2; }

                if (_playerScript.WallIn[i].gameObject.activeSelf == true)
                {
                    _playerScript.WallIn[2].SetActive(true);
                    _playerScript.WallIn[3].SetActive(true);
                }
                
            }
            else 
            {

                if (rn > 0.5)
                {
                    i = 1;
                }
                else { i = 0; }
               
            }

            
            Destroy(collision.gameObject);
            _playerScript.WallIn[i].gameObject.SetActive(true);
        }

        


        if (collision.gameObject.layer == 11)
        {
           
            if (_playerScript.Player2 == true)
            {
                _playerScript.Score += scr_GameLogic.ScorePlus;
                Destroy(collision.gameObject);
                _playerScript.ScoreTextP2.text = "" + _playerScript.Score;
            }
            else 
            {
                _playerScript.Score += scr_GameLogic.ScorePlus;
                _playerScript.ScoreTextP1.text = "" + _playerScript.Score;
                Destroy(collision.gameObject);
            }
        }



        if (collision.gameObject.layer == 12)
        {

            Destroy(collision.gameObject);
            scr_GameLogic.BallCount += 1;
            CreateBall();

          
            
        }

        if (collision.gameObject.layer == 15)
        {
            MGLogic.Score += 1;
            ReDo();

        }

        if (collision.gameObject.layer == 16)
        {
            MGLogic.Score -= 1;
            ReDo();

        }
    }

    private void ReDo()
    {
        GameInProgres = false;
        PreGameStart = false;
        _startTimer = 1;
        RB.linearVelocity = new Vector2( 0 , 0 );
        transform.position = new Vector3(0, 0, 0);
    }

    

    private void CreateBall()
    {
        var NewBall = Instantiate(gameObject, gameObject.transform.position , gameObject.transform.rotation);
        NewBall.GetComponent<scr_ball>().Player = Player;
        NewBall.GetComponent<scr_ball>()._playerScript = _playerScript;
        NewBall.GetComponent<scr_ball>().PreGameStart = true;
        NewBall.GetComponent<scr_ball>().GameInProgres = false;




    }

   
}
