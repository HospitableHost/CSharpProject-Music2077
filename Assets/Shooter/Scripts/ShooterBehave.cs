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
    private bool[] Track;        //存储12条通道是否使用的数组
    private List<Note.Note> Music;   //深复制存储乐谱的链表
    private void Shoot() {  }        //根据乐谱链表，发射一个Quad
    void Start() { }      //初始化游戏的时间
    void FixedUpdate() { }    //根据时间判断发射与否
    private void ImportMusic(List<Note.Note> OriginMusic) { }
}

