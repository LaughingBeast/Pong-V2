using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class scr_GameLogic : MonoBehaviour
{
    public List<GameObject> Balls;
    public TMP_Text RoundTimeText;
    public GameObject Playe1;
    public GameObject Playe2;

    bool _timerTick;

    public bool Player1PointCap;
    public bool Player2PointCap;

    static public int BallCount = 2;
    static public int ScorePlus = 1;
    private int _rNumberPlusWall;
    public int RNumberPlusPoint;
    private int _rNumberPlusBall;

    public float RoundTimeBasic;
    private float _roundTimeActual;
    private float _oneSecond = 1;
    private int _secondCounter;

    


    void Start()
    {
       



         Player1PointCap = false;
         Player2PointCap = false;

        _timerTick = false;
        _roundTimeActual = RoundTimeBasic;
        _oneSecond = 1;

        float rn;
        rn = (Random.value);
         if (rn < 0.5f )
        {
            _rNumberPlusWall = 1;
        } else { _rNumberPlusWall = 2; }

        
        RNumberPlusPoint = Random.Range(10, 25);
        _rNumberPlusBall = Random.Range(1, 4);
     

        for (int i = 1; i <= _rNumberPlusWall; i++)
        {
            Instantiate(Balls[0], new Vector3(Random.Range(-1, -7.5f), Random.Range(-1, 1.5f), 0), transform.rotation);
            
            Instantiate(Balls[0], new Vector3(Random.Range(1.5f, 8), Random.Range(-1, 1.5f), 0), transform.rotation);
            
        }
        for (int i = 1; i <= RNumberPlusPoint; i++)
        {
           Instantiate(Balls[1], new Vector3(Random.Range(-1,-7.5f), Random.Range(-1,1.5f),0), transform.rotation);
           Instantiate(Balls[1], new Vector3(Random.Range(1.5f, 8), Random.Range(-1, 1.5f), 0), transform.rotation);
          
        }
        for (int i = 1; i <= _rNumberPlusBall; i++)
        {
            Instantiate(Balls[2], new Vector3(Random.Range(-1, -7.5f), Random.Range(-1, 1.5f), 0), transform.rotation);
            Instantiate(Balls[2], new Vector3(Random.Range(1.5f, 8), Random.Range(-1, 1.5f), 0), transform.rotation);
            
        }
    }
    
    
    void Update() 
    {
       
        if (_roundTimeActual != 0 && _oneSecond > 0)
        {
            _oneSecond -= Time.deltaTime;
            

        }

        if (_oneSecond <= 0 )
        {
            _roundTimeActual -= 1;
            RoundTimeText.text = " " + _roundTimeActual;
            _oneSecond = 1;
        }
       
        if ( _roundTimeActual <= 0)
        {
            RoundEnd();
        }

        if (Player1PointCap == true )
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Balls[1], new Vector3(Random.Range(-1, -7.5f), Random.Range(-1, 1.5f), 0), transform.rotation);
                
            }
            Player1PointCap = false;
        }

        if (Player2PointCap == true )
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Balls[1], new Vector3(Random.Range(1.5f, 8), Random.Range(-1, 1.5f), 0), transform.rotation);
                
            }

            Player2PointCap = false;
        }


        if (BallCount <= 0)
        {
            RoundEnd();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
    }

    public void RoundEnd() 
    {
        scr_ShopManager.MoneyP1 = Playe1.GetComponent<scr_Player>().Score;
        scr_ShopManager.MoneyP2 = Playe2.GetComponent<scr_Player>().Score;
        SceneManager.LoadScene(2);
    }
}
