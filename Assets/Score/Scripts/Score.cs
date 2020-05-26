using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

namespace Score
{
    public class Score
    {
        public int totalScore { get; set; }  //总分

        public int missNum { get; set; }   //miss掉的方块数

        public int goodNum { get; set; }  //good级命中数

        public int perfectNum { get; set; } //perfect评分方块数
    }

}
