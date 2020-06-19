﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    public enum Difficulty
    {
        easy,  //容易
        difficult  //困难
    }
    public class Settings
    {

        static public float velocity { get; set; } = 0.0f;  //音符飞行的速度
        static public Difficulty difficulty = Difficulty.easy;  //难易程度
        static public float SurfacePos { get; set; } = 0.5f;  //2160×1080的变色面在z=0.5   1920×1080的变色面在z=0.7 
        static public float edgePos { get; set; } = -0.66f;//这是屏幕边缘平面，当quad的远离按键的一边的中点的z坐标小于它时，quad就完全不见了。2160*1080时为z=-0.66；1920*1080时为z=-0.12
        static public string ChosenSong { get; set; }  //所选的歌曲拼音名
    }
}

