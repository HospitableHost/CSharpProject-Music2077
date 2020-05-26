using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class LongQuadBehave : QuadBehave
{
    bool IsValid;//音符是否有效
    //use this to init
    public void Initialize(Note.Note_NoteStrip note)
    {
        m_quad = Resources.Load<GameObject>("Prefabs/LongQuad");
        m_note = note;
    }

    //todo:检测触摸判断
    override public bool CheckHit()
    {
        return false;
    }
    override public bool CheckOut()
    {
        return base.CheckOut();
    }
    //todo:统计分数加到计分板上
    override public void MarkRecording()
    {

    }

}

