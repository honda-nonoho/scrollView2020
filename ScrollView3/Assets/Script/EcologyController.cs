using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EcologyController : MonoBehaviour
{
    //EcologyImage
    [SerializeField] private Image _EcologyImage = null;
    //EcologyText
    [SerializeField] private Text _EcologyText  = null;
    //BuckButton3
    [SerializeField] private Button _BuckButton3 = null;
    void Start()
    {
        // もどるボタンのイベント登録
         _BuckButton3.onClick.AddListener(OnClickBuckButton3);
        
         // Jsonを呼び出す
        string inputString = Resources.Load<TextAsset>("Json/test").ToString();
        Debug.Log(inputString);
        TestJsonParent inputJson = JsonUtility.FromJson<TestJsonParent>(inputString);
        //idを取得してセーブする
        int id = PlayerPrefs.GetInt("id");
        
        Debug.Log("id" + id);

         //iは０、i(0)より大きい場合に、Jsonをインプットする関数を呼び出してdataを読み込んで、Length(文字数を読み込む).i++でループさせて
            for(int i = 0; i < inputJson.data.Length; i++)
            {
                //もし異なった場合は処理を続けてください
                if(inputJson.data[i].id != id) continue;

                //Sprite(画像)　inputSprite は　リソーシズでロードして(Sprite)です（リソーシズ＞ImageとJsonからdeta[1~4]の数値、EcologyImageを取得してください
                Sprite inputSprite = Resources.Load<Sprite>("Image/" + inputJson.data[i].ecologyImage);
                // EcologyImageはSpriteで上記のSpriteでロードします
                _EcologyImage.sprite = inputSprite;
                //これはで_EcologyText  は Jsonからdeta[1~4]の数値、nameを取得してください
                this._EcologyText .text = inputJson.data[i].ecologyText; 

                break;
            }

    }

    void OnClickBuckButton3()
    {
        SceneManager.LoadScene("DetailScene");
        Debug.Log("OnClickButton");
        
    }
}
