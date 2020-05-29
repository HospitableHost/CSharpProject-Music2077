using Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class LongQuadBehave : QuadBehave
{ 
    private Note_NoteStrip currentNoteStrip;
    //use this to init
    public void Initialize(Note.Note_NoteStrip note)
    {
        m_quad = Resources.Load<GameObject>("Prefabs/LongQuad");
        m_note = note;
        currentNoteStrip = note;
    }

    //todo:检测触摸判断
    override public bool CheckHit()
    {
        return false;
    }
    override public bool CheckOut()
    {
        if (m_nowPos.z + currentNoteStrip.lastTime / 2 == 0/* 最后的边界变为了0 */)
            return true;
        return false;
    }
    //todo:统计分数加到计分板上
    override public void MarkRecording()
    {
    }

}

