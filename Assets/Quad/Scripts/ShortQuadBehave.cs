using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortQuadBehave : QuadBehave
{

    //use this to init
    public void Initialize(Note.Note_NoteBar note)
    {
        m_quad = Resources.Load<GameObject>("Prefabs/ShortQuad");
        m_note = note;
    }

    //todo:检测触摸判断
    override public bool CheckHit()
    {
        return false;
    }
    //todo:出边界检测
    public override bool CheckOut()
    {
        return base.CheckOut();
    }
    //todo:统计分数加到计分板上
    override public void MarkRecording()
    {

    }


}
