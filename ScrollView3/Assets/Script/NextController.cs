using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextController : MonoBehaviour
{

    //各UI
    
    [SerializeField] private Image _Image1 = null;
    [SerializeField] private Image _Image2 = null;
    [SerializeField] private Image _Image3 = null;
    [SerializeField] private Text _Text1 = null;

    [SerializeField] private Text _Text2 = null;

    [SerializeField] private Text _Text3 = null;
    //BuckButton2
    [SerializeField] private Button _BuckButton2 = null;

    void Start()
    {
        // もどるボタンのイベント登録
         _BuckButton2.onClick.AddListener(OnClickBuckButton2);
        // Jsonを呼び出す
        string inputString = Resources.Load<TextAsset>("Json/test").ToString();
        Debug.Log(inputString);
        TestJsonParent inputJson = JsonUtility.FromJson<TestJsonParent>(inputString);
        //idを取得してセーブする
        int id = PlayerPrefs.GetInt("id");
        
        Debug.Log("id" + id);

        for(int i = 0; i < inputJson.data.Length; i++)
            {

                //もし異なった場合は処理を続けてください
                if(inputJson.data[i].id != id) continue;
        

        //Sprite(画像)　inputSprite は　リソーシズでロードして(Sprite)です（リソーシズ＞ImageとJsonからdeta[1~4]の数値、Image1~3を取得してください
                Sprite inputSprite1 = Resources.Load<Sprite>("Image/" + inputJson.data[i].image1);
                //_FaceImage はSpriteで上記のSpriteでロードします
                _Image1.sprite = inputSprite1;
               
                //Image2
                Sprite inputSprite2 = Resources.Load<Sprite>("Image/" + inputJson.data[i].image2);
                _Image2.sprite = inputSprite2;
               
                //Image3
                Sprite inputSprite3 = Resources.Load<Sprite>("Image/" + inputJson.data[i].image3);
                _Image3.sprite = inputSprite3;
               

                //これは_Text1~3でtext は Jsonからdeta[1~4]の数値、text1~3を取得してください
                this._Text1.text = inputJson.data[i].text1; 
                this._Text2.text = inputJson.data[i].text2; 
                this._Text3.text = inputJson.data[i].text3; 
                
                break;
            }

        
    }

    //BuckButton2
    void OnClickBuckButton2()
    {
        SceneManager.LoadScene("DetailScene");
        Debug.Log("OnClickBuckButton2");
    }


}
