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
    override public bool CheckHit()
    {
        if (this.IsValid == false) return false;//按键若失效 直接失败

        double borderLine = 0;//合法检测区
        int scoreLevel = 0; //表示得分的等级 5 - good     10 - perfect      0 - miss
        int sForBar= MusicScore.MusicScoreManager.musicScore.scorePerSecOfNoteStrip;
        switch (Screen.width)
        {
            case 2160: borderLine = 0.1; break;
            case 1920: borderLine = 0.7; break;
            default: break;
        }
        //Vector3 CameraPos = new Vector3(0, 0, -5);//摄像机的世界坐标
        //Vector3 TouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray[] allTouchRay = this.getAllRaysThroughTouches();


        foreach (Ray ray in allTouchRay)
        {


            RaycastHit result;
            int layerMask = ~(1<<0);
            if (Physics.Raycast(ray, out result, layerMask))
            {
                double distance = this.m_nowPos.z;//获取按键的y坐标
                if (distance > borderLine) return false;//在合法触摸区之外 直接返回
                
                if (distance < GoodRight && distance > PerfectRight)
                {
                    Debug.Log("good");
                    scoreLevel = 5;//Good
                    Score.Score.totalScore += scoreLevel * sForBar;
                    Score.Score.goodNum += 1;
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                else if (distance > PerfectLeft)
                {
                    Debug.Log("perfect");

                    scoreLevel = 10;//perfect 得分
                    Score.Score.totalScore += scoreLevel * sForBar;
                    Score.Score.perfectNum += 1;
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                else if (distance > GoodLeft)
                {
                    Debug.Log("good");

                    scoreLevel = 5;//good得分
                    Score.Score.totalScore += scoreLevel * sForBar;
                    Score.Score.goodNum += 1;
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                //Score.Score.missNum += 1;
                return false;//miss
            }
        }

        return false;//不应该从这里返回  前面涵盖了所有情况

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
    /*  函数功能合并到CheckHit（）   此函数弃用
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

    }*/


}
