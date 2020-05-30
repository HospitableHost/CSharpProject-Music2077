using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Score;

public class QuadBehave : MonoBehaviour
{
    public delegate void hitManage();//特效处理
    public event hitManage hitQuad;//击中事件
    protected Vector3 m_nowPos;
    public bool IsValid { get; set; } = true;
    //load prefab
    protected GameObject m_quad;

    protected Note.Note m_note;
    [SerializeField]
    static public float SurfacePos { get; set; } = 0.1f;
    [SerializeField]
    static protected float erreurGood=0.75f, erreurPerfect=0.1875f;

    [SerializeField]
    static public float m_vel;

    static public float GoodLeft { get { return SurfacePos - erreurGood; } }
    static public float GoodRight { get { return SurfacePos + erreurGood; } }
    static public float PerfectLeft { get { return SurfacePos - erreurPerfect; } }
    static public float PerfectRight { get { return SurfacePos + erreurPerfect; } }

    //use this to init
    virtual public void Initialize(Note.Note note) { }

    // Start is called before the first frame update
    protected void Start()
    {
        m_quad = this.gameObject;
        Background.Background.SetPositionAtTrack(transform, m_note.trackNum);
        m_nowPos = transform.position;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (CheckOut())
        {
            QuadPool.Die(this.gameObject);
        }
        else if (CheckHit())
        {
            hitQuad();
        }
        else
        {
            m_nowPos.Set(m_nowPos.x, m_nowPos.y, m_nowPos.z - m_vel * Time.deltaTime);
            this.transform.position = m_nowPos;
        }
    }

    //todo:检测触摸判断
    virtual public bool CheckHit()
    {
        return false;
    }
    //todo:检测触摸判断
    virtual public bool CheckHit(Score.Score scoreBoard)
    {
        return false;
    }

    virtual public bool CheckOut()
    {
        return false;
    }
    //todo:统计分数加到计分板上
    virtual public void MarkRecording()
    {

    }
    //todo:统计分数加到计分板上
    virtual public void MarkRecording(Score.Score scoreBoard,int score)
    {

    }


    static public void SetErreur(float goo, float per)
    {
        erreurGood = goo;
        erreurPerfect = per;
    }
    static public void SetVel(float vel)
    {
        m_vel = vel;
    }


    public Vector3[] getPositionsInUnityWorldOfAllTouches()  //这个函数获得所有触摸的Unity世界坐标
    {
        Vector3[] touchPositions = new Vector3[Input.touches.Length];//touchPositions数组存放这一帧检测到的所有touch的转换到unity世界中的坐标
        Vector3 CameraPos = new Vector3(0, 0, -5);//摄像机的世界坐标
        for (int i = 0; i < Input.touches.Length; i++)
        {
            touchPositions[i] = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        }
        return touchPositions;
    }


    //判断给定的触摸集合中是否含有指定通道按键处的触摸,touchPositions是所有触摸在Unity世界中的坐标的数组，tracknum是要判断的哪个通道上的按键
    public bool haveTouchOfTheTrack(Vector3[] touchPositions, int tracknum)
    {
            switch (tracknum)
            {
                case 0:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > -5 && touch.x < -2.5 && touch.y == -2.5)
                            return true;
                    }
                    return false;
                case 1:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > -2.5 && touch.x < 0 && touch.y == -2.5)
                            return true;
                    }
                    return false;
                case 2:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > 0 && touch.x < 2.5 && touch.y == -2.5)
                            return true;
                    }
                    return false;
                case 3:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > 2.5 && touch.x < 5 && touch.y == -2.5)
                            return true;
                    }
                    return false;
                case 4:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.y > -2.5 && touch.y < 0 && touch.x == 5)
                            return true;
                    }
                    return false;
                case 5:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.y > 0 && touch.y < 2.5 && touch.x == 5)
                            return true;
                    }
                    return false;
                case 6:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > 2.5 && touch.x < 5 && touch.y == 2.5)
                            return true;
                    }
                    return false;
                case 7:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > 0 && touch.x < 2.5 && touch.y == 2.5)
                            return true;
                    }
                    return false;
                case 8:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > -2.5 && touch.x < 0 && touch.y == 2.5)
                            return true;
                    }
                    return false;
                case 9:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.x > -5 && touch.x < -2.5 && touch.y == 2.5)
                            return true;
                    }
                    return false;
                case 10:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.y > 0 && touch.y < 2.5 && touch.x == -5)
                            return true;
                    }
                    return false;
                case 11:
                    foreach (Vector3 touch in touchPositions)
                    {
                        if (touch.z < QuadBehave.SurfacePos && touch.y > -2.5 && touch.y < 0 && touch.x == -5)
                            return true;
                    }
                    return false;
                default:
                    return false;
            }
    }
}

