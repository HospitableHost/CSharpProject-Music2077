﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Note
{
    public enum NoteType
    {
        NoteBar,  //音符块
        NoteStrip  //音符条（此种音符条一直在一个通道上，不会跳变）
    }
    public class Note  //音符基类，支持音符的扩展
    {
        public NoteType noteType;  //这个Node的音符种类
        public int trackNum;  //这个音符将要出现在第几轨道
        public float arrivalTime;  //这个音符到达按键的时间，“音符到达按键”定义为：音符在unity世界中的z坐标为0的时刻

        public Note(NoteType noteType, int trackNum, float arrivalTime)
        {
            this.noteType = noteType;
            this.trackNum = trackNum;
            this.arrivalTime = arrivalTime;
        }
    }
    public class Note_NoteBar : Note  //第一种音符:音符块
    {
        public Note_NoteBar(int trackNum, float arrivalTime) : base(NoteType.NoteBar, trackNum, arrivalTime)
        {

        }
    }
    public class Note_NoteStrip : Note  //第二种音符：音符条
    {
        public float lastTime;  //持续时间，这种音符要一直按着屏幕直到音符消失，这个持续时间定义为：从音符到达按键的时刻开始持续多久

        public Note_NoteStrip(int trackNum, float arrivalTime, float lastTime) : base(NoteType.NoteStrip, trackNum, arrivalTime)
        {
            this.lastTime = lastTime;
        }
    }
}