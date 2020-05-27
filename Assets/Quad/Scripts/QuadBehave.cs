using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


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
    static protected float erreurMiss, erreurGood, erreurPerfect;

    [SerializeField]
    static protected float m_vel;

    //use this to init
    virtual public void Initialize(Note.Note note) { }

    // Start is called before the first frame update
    protected void Start()
    {
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
            MarkRecording();
            if (IsValid == false)
            {
                QuadPool.Die(this.gameObject);
            }
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
    virtual public bool CheckOut()
    {
        return false;
    }
    //todo:统计分数加到计分板上
    virtual public void MarkRecording()
    {

    }



    static public void SetErreur(float mis, float goo, float per)
    {
        erreurMiss = mis;
        erreurGood = goo;
        erreurPerfect = per;
    }
    static public void SetVel(float vel)
    {
        m_vel = vel;
    }

}

