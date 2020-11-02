using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ContentController : MonoBehaviour
{
    //id= int型(test.Json)
    public int id;
    //Buttonについて,Maincontrollerで使ってるコンテンツのUIの宣言
    [SerializeField] private Button _MainButton = null;
    //MainContentのボタンの上の画像の宣言
    [SerializeField] private Image _MainImage = null;
   

    // Start is called before the first frame update
    void Start()
    { 
        //ボタンを押した時に呼び出される、イベント登録のメゾット
         _MainButton.onClick.AddListener(onClickMainButton);
        
    }
    void onClickMainButton()
    {
        //Jsonデータに飛ぶように
        PlayerPrefs.SetInt("id", id);
        SceneManager.LoadScene("DetailScene");
    }

    //Jsonデータ(id)
    public void SetId(int dataId)
    {
        id = dataId;
    }

    //Jsonデータ(Sprite:画像)
    public void SetSprite(Sprite sprite)
    {
        Debug.Log(sprite);
         _MainImage.sprite = sprite;

    }
}
