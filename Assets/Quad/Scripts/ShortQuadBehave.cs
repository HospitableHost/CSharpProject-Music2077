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


    new public Ray[] getAllRaysThroughTouches()  //这个函数获得所有从相机出发，经过手机屏幕上触摸点的Unity世界中的射线
    {
        Vector3[] touchPositions = new Vector3[Input.touches.Length];//把像素坐标存成Vector3，z为0，因为z在后边会自动忽略       
        for (int i = 0; i < Input.touches.Length; i++)
        {
            touchPositions[i].x = Input.touches[i].position.x;
            touchPositions[i].y = Input.touches[i].position.y;
            touchPositions[i].z = 0;

            Debug.Log(touchPositions[i].x + touchPositions[i].y);
        }
        Ray[] allRays = new Ray[Input.touches.Length];
        for (int i = 0; i < Input.touches.Length; i++)
        {
            allRays[i] = Camera.main.ScreenPointToRay(touchPositions[i]);
            //Debug.Log(allRays[i].x + allRays[i].y + allRays[i].z);
        }
        return allRays;

    }


    //todo:检测触摸判断
    override public bool CheckHit(Score.Score scoreBoard)
    {
        Debug.Log("hit");
        double borderLine = 0;//合法检测区
        int scoreLevel = 0; //表示得分的等级 5 - good     10 - perfect      0 - miss
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

            if (Physics.Raycast(ray, out result))
            {
                double distance = this.m_nowPos.z;//获取按键的y坐标
                if (distance > borderLine) return false;//在合法触摸区之外 直接返回
                
                if (distance < GoodRight && distance > PerfectRight)
                {
                    Debug.Log("good");
                    scoreLevel = 5;//Good
                    this.MarkRecording(scoreBoard, scoreLevel);
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                else if (distance > PerfectLeft)
                {
                    Debug.Log("perfect");

                    scoreLevel = 10;//perfect 得分
                    this.MarkRecording(scoreBoard, scoreLevel);
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                else if (distance > GoodLeft)
                {
                    Debug.Log("good");

                    scoreLevel = 5;//good得分
                    this.MarkRecording(scoreBoard, scoreLevel);
                    this.IsValid = false;//触摸一次之后按键失效处理
                    return true;
                }
                return false;//miss
            }


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
