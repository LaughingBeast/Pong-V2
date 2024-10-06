using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scr_MainGameLogic : MonoBehaviour
{
    public GameObject Ball;

    public TMP_Text ScoreText;

    int _score;


    
    public int Score
    {
        get
        { 
            return _score;
        }

        set
        {
            _score = value;
            ScoreColorLogic();
            ScoreText.text = Math.Abs(value).ToString(); // Math.Abs() zjištujì absolutní èíslo hodnoty 
        }
    }
   
    private void ScoreColorLogic ()
    {
        if (_score >= 1 )
        {
            ScoreText.color = Color.green;
        } else if (_score <= -1)
        {
            ScoreText.color = Color.red;
        } else { ScoreText.color = Color.white; }

    }

    

    


}
