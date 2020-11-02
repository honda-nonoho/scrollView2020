using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DetailController : MonoBehaviour
{
    //各UIの宣言
    //NameText
    [SerializeField] private Text _Name = null;
    //Video Player
     [SerializeField] private VideoPlayer _Video = null;
     //IntroductionText
     [SerializeField] private Text _Introduction = null;
     //FaceImage
     [SerializeField] private Image _FaceImage = null;
     //BuckButton
     [SerializeField] private Button _BuckButton = null;
     
     //NextButton
     [SerializeField] private Button _NextButton = null;
     //EclogyButton
      [SerializeField] private Button _EcologyButton = null;




    
    void Start()
    {
        // もどるボタンのイベント登録
         _BuckButton.onClick.AddListener(OnClickBuckButton);
        
        //Nextボタンのイベント登録
        _NextButton.onClick.AddListener(OnClickNextButton);

        //EcologyButtonのイベント登録
        _EcologyButton .onClick.AddListener(OnClickEcologyButton);


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
                Debug.Log("_Name");
                //これは_Nameでtext は Jsonからdeta[1~4]の数値、nameを取得してください
                this._Name.text = inputJson.data[i].name; 
                //これは_Introduction.text は　Jsonからdeta[1~4]の数値、introductionを取得してください
                this._Introduction.text = inputJson.data[i].introduction;
                //Sprite(画像)　inputSprite は　リソーシズでロードして(Sprite)です（リソーシズ＞ImageとJsonからdeta[1~4]の数値、faceImageを取得してください
                Sprite inputSprite = Resources.Load<Sprite>("Image/" + inputJson.data[i].faceImage);
                //_FaceImage はSpriteで上記のSpriteでロードします
                _FaceImage .sprite = inputSprite;
                //即再生されるのを防ぐ.
                _Video.playOnAwake = false;
                // パス or VideoClip を設定.
                _Video.url = "Assets/Movie/" + inputJson.data[i].moviepath + ".mov";
                // videoPlayer.clip = videoClip;
                // 読込完了時のコールバックを設定.
                _Video.prepareCompleted += PrepareCompleted;
                
                // 読込開始.
                _Video.Prepare();

            
                break;
            }
        Debug.Log(inputJson.data.Length); 
      
        Debug.Log(PlayerPrefs.GetInt("id"));

    }

    //_BuckButton
    void OnClickBuckButton()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("OnClickBuckButton");
    }

    //NextButton
    void OnClickNextButton()
    {
        SceneManager.LoadScene("NextScene");
        Debug.Log("OnClickNextButton");

    }

    //EcologyButton
    void OnClickEcologyButton()
    {
        SceneManager.LoadScene("EcologyScene");
        Debug.Log("EcologyButton");

    }

    //VideoPlayer
    void PrepareCompleted(VideoPlayer vp)
    {
        vp.prepareCompleted -= PrepareCompleted;
        vp.Play();

    }
    
}
