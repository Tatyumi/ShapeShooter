using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class TitleDirector : MonoBehaviour
{
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Start()
    {
        // 初期化
        Initialize();
    }


    // Update is called once per frame
    void Update()
    {
        // 画面がタップされた場合
        if (Input.GetMouseButtonDown(0))
        {
            // 音楽停止
            //audioManager.StopSound();

            // 最初のステージに移行
            SceneManager.LoadScene(SceneName.FIRST_STAGE_SCENE);
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 音楽データの取得
        //audioManager = AudioManager.Instance;

        // 残機数初期化
        LifeCountTextController.LifeCount = 3;

        // TODO BGMの再生
    }
}
