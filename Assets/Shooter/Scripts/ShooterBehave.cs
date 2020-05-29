using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    private void Shoot()    //根据乐谱链表，发射一个Quad
    {
        GameObject q = Resources.Load<GameObject>("Prefabs/ShortQuad");
        Background.Background.SetPositionAtTrack(transform, Music[i].trackNum);
        GameObject quad = QuadPool.Born(q, transform.position, transform.rotation);   //生成quad
        if(Music[i].noteType == Note.NoteType.NoteBar)   //按类型绑定脚本
        {
            ShortQuadBehave qb = quad.AddComponent<ShortQuadBehave>();   
            qb.Initialize(Music[i]);
        }
        else
        {
            LongQuadBehave qb = quad.AddComponent<LongQuadBehave>();
            qb.Initialize(Music[i]);
        }    
    }     
    void Start()    //初始化游戏的时间和乐谱音符计数
    {
        i = 0;
        time = 50 / QuadBehave.m_vel;
    }   
    void FixedUpdate()    //根据时间判断发射与否
    {

        if (Music[i] != null)
        {       
            Note.Note currentNote = Music[i];
            if (Time.time >= currentNote.arrivalTime-time)
            {
                Shoot();
                i++;
            }
        }
    }
    private void ImportMusic(List<Note.Note> OriginMusic) 
    {
        using (MemoryStream ms = new MemoryStream())  //使用序列化+反序列化进行深复制
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, OriginMusic);
            ms.Position = 0;
            Music = (List<Note.Note>)bf.Deserialize(ms);
        }
    }
}

