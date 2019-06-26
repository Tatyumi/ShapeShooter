using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public sealed class TitleDirector : MonoBehaviour
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
        // スペースキーを押したか判別
        if (Input.GetKey(KeyCode.Space))
        {
            // 押した場合

            // 音楽停止
            audioManager.StopSound();

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
        audioManager = AudioManager.Instance;

        // 残機数初期化
        LifeCountTextController.LifeCount = 3;

        // スコアの初期化
        ScoreController.score = 0;

        // 破壊した敵キャラの数を初期化
        ResultPanelController.EnemyKillCount = 0;

        // 1upスコアの初期化
        ScoreController.OneUpScore = ScoreController.OneUpScoreBaseValue;

        // プレイヤーレベルの初期化
        PlayerListsController.PlayerLevel = 0;

        // BGMの再生
        audioManager.PlayBGM(audioManager.TitleSceneBGM.name);
    }
}
