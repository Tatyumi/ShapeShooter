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
        // 画面がクリックされた場合
        if (Input.GetMouseButtonDown(0))
        {
            // 音楽停止
            //audioManager.StopSound();

            // インスタンス取得
            var SceneName = new SceneName();

            // 最初のステージに移行
            SceneManager.LoadScene(SceneName.STAGE_NAMES[0]);
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

        // スコアの初期化
        ScoreController.score = 0;

        // 破壊した敵キャラの数を初期化
        ResultPanelController.EnemyKillCount = 0;

        // TODO BGMの再生
    }
}
