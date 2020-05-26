using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEngine;
using Note;
using System.Runtime.Serialization.Formatters.Binary;
//using UnityEditor.Experimental.GraphView;

namespace MusicScore
{
    [Serializable]
    public class MusicScore
    {
        public List<Note.Note> musicScore;  //不需要写索引器，它自身就可以用[]去访问
        public int scoreOfNoteBar;  //这个乐谱中音符块的分数：成功按下音符块的分数
        public int scorePerSecOfNoteStrip;  //这个乐谱中音符条每秒的分数：按下1s能加的分数
        public MusicScore()
        {
            musicScore = new List<Note.Note>();
        }
    }

    public class MusicScoreManager
    {
        public MusicScore musicScore = new MusicScore();
        public void ExportToJSON(string name)  //把musicScore导出为JSON格式文件，进行数据持久化，导出的位置在一个固定的文件夹内，name是文件名
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + name + ".json";

            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, musicScore);
            fs.Close();
        }

        public void ImportFromJSON(string name)  //因为我们的乐谱json是放在固定文件夹里的，所以只需给个参数:文件名name就可以了，name就是文件名，把这个文件里的JSON对象：MusicScore导入，赋值给静态成员musicScore
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + name + ".json";
            if (File.Exists(filepath))
            {
                FileStream fs = new FileStream(filepath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                MusicScore msobj = (MusicScore)bf.Deserialize(fs);
                musicScore = msobj;
                fs.Close();
            }
        }
    }


}
