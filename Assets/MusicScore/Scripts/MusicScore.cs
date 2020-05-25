using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEngine;
using Note;
//using UnityEditor.Experimental.GraphView;

namespace MusicScore
{
    public class MusicScore
    {
        public List<Note.Note> musicScore;  //不需要写索引器，它自身就可以用[]去访问
        public MusicScore()
        {
            musicScore = new List<Note.Note>();
        }
    }

    public class MusicScoreManager
    {
        static MusicScore musicScore = new MusicScore();
        static void ExportToJSON(string name)  //把musicScore导出为JSON格式文件，进行数据持久化，导出的位置在一个固定的文件夹内，name是文件名
        {
        }

        static void ImportFromJSON(string name)  //因为我们的乐谱json是放在固定文件夹里的，所以只需给个参数:文件名name就可以了，name就是文件名，把这个文件里的JSON对象：MusicScore导入，赋值给静态成员musicScore
        {
        }
    }


}
