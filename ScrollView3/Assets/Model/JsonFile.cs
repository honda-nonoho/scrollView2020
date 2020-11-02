using System;
using UnityEngine;
using UnityEngine.UI;

// key 親
[Serializable] public class TestJsonParent
{
    public TestJsonChild[] data;
}

// key 子
    [Serializable] public class TestJsonChild
    {
        public int id;
        public string name;
        //自己紹介
        public string introduction;

        //顔写真
        public string faceImage;
        //動画
        public string moviepath;

        //NextSceneのimage,text
        public string image1;
        public string image2;
        public string image3;
        public string text1;
        public string text2;
        public string text3;

        //EcologyScene
        public string ecologyImage;
        public string ecologyText;


        
    }