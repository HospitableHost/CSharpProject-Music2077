using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    float time;
    private int i;    //对List列表进行计数
    private bool[] Track;        //存储12条通道是否使用的数组
    private List<Note.Note> Music;   //深复制存储乐谱的链表
    private void Shoot() { }        //根据乐谱链表，发射一个Quad
    void Start() { }      //初始化游戏的时间
    void FixedUpdate()    //根据时间判断发射与否
    {

        if (Music[i] != null)
        {       
            Note.Note currentNote = Music[i];
            if (Time.time == currentNote.arrivalTime-time)
            {
                Shoot();
                i++;
            }
        }
    }
    private void ImportMusic(List<Note.Note> OriginMusic) { }
}

