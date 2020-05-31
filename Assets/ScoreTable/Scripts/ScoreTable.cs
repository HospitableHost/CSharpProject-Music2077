using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTable : MonoBehaviour
{
    private Score.Score score=new Score.Score();
    [SerializeField]
    private Text text ;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Music\n2077";    //初始化设置为Music 2077
        score.totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (score.totalScore != 0 )    //当分数发生改变的时候，原先显示music2077的界面变为计分板
        {
            text.text = Convert.ToString(score.totalScore);
        }
        else
        {
            text.text= "Music\n2077";
        }
        score.totalScore++;
    }
}
