using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

public class ShortQuadBehave : QuadBehave
{

    //use this to init
    public void Initialize(Note.Note_NoteBar note)
    {
        m_note = note;
    }

    //todo:检测触摸判断
    override public bool CheckHit(Score.Score scoreBoard)
    {
        int score = 0;
        Vector3 CameraPos = new Vector3(0, 0, -5);//摄像机的世界坐标
        Vector3 TouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (TouchPos.z > 5)//在合法触摸区之外
        {
            return false;
        }

        RaycastHit result;
        if (Physics.Raycast(CameraPos, TouchPos, out result))
        {
            double distance = this.m_nowPos.z;//获取按键的z坐标

            if (distance > erreurMiss)
            {
                score = 0;
            }
            else if (distance > erreurGood)
            {
                score = 10;//good 得分
            }
            else if (distance > -erreurPerfect)
            {
                score = 20;//完美得分
            }

            this.MarkRecording(scoreBoard, score);
            this.IsValid = false;//触摸一次之后按键失效处理
            return true;//成功触摸
        }


        return false;//在触摸区内但是没有触摸
    }
    //todo:出边界检测
    public override bool CheckOut()
    {
        if (m_nowPos.z < -5)
        {
            IsValid = false;
            return true;
        }
        else
            return false;
    }
    //todo:统计分数加到计分板上
    public void MarkRecording(Score.Score scoreBoard, int ScoreToAdd)
    {

        scoreBoard.totalScore += ScoreToAdd;
        if (ScoreToAdd == 20)//perfect
        {
            scoreBoard.perfectNum++;
        }
        else if (ScoreToAdd == 10)//good
        {
            scoreBoard.goodNum++;
        }
        else//others are miss
        {
            scoreBoard.missNum++;
        }

    }


}
