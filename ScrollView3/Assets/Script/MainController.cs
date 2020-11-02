using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    //オブジェクトの宣言
    [SerializeField] private GameObject _MainObject = null;

    //コンテンツについて
    private ContentController _Maincontent = null;

    //コンテンツのUI
    const string _From = "Prefab/Button";
    //_Loopはint型　オブジェクトを何個繰り返すか
    int _Loop = 0;
    //timeはfloat型　何秒後に表示するのか
    private float time;
    //Sprite(画像)を表示する
    public string[] _MainSprites = new string[4];
    // Start is called before the first frame update
    void Start()
    {
        Load();
        Debug.Log("Start");
        
    }


    void Update()
    {
        //もし_Loopが４ならreturnで返す
        if(_Loop == 4) return;

        //だいたい1.0秒ごとに処理を行う
        time -= Time.deltaTime;
        if (time <= 0.0) {
            time = 1.0f;

            var Sprite = Resources.Load<Sprite>("Image/" + _MainSprites[_Loop]);
            
            _Loop++;
            //ここに処理

            var Prefab  = Instantiate<ContentController>(_Maincontent, Vector3.zero, Quaternion.identity, _MainObject.transform);

            Prefab.SetId(_Loop);
            Prefab.SetSprite(Sprite);
    
        }
        
    }
    // MainContentがどこから読みこんでいるのか
    void Load()
    {
        //_Maincontent = リソーシズ＞Load>ContentControllerで情報があって＞UIは_Fromから持ってくる
        _Maincontent = Resources.Load<ContentController>(_From);
        Debug.Log("Load");
    }
}
