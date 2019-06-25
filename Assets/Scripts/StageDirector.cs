using Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StageDirector : MonoBehaviour
{
    /// <summary>挑戦したステージ名</summary>
    public static string ChallengeStageName;
    /// <summary>ステージのBGM名</summary>
    public string StageBgmName;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(StageBgmName);

        // フラグ初期化
        PauseManager.isPause = false;

        // シーン開始時に敵キャラ破壊数を初期化
        ResultPanelController.TempEnemyKillCount = 0;

        // ステージ名の取得
        ChallengeStageName = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// クリアしたステージに応じて次のステージ
    /// </summary>
    /// <param name="stageName"></param>
    /// <returns></returns>
    public static void NextStageMove(string stageName)
    {
        // インスタンス取得
        var sceneName = new SceneName();

        // 現在のステージに該当する要素番号を取得
        int stageIndex = Array.IndexOf(sceneName.STAGE_NAMES, stageName);

        // 現在のステージの要素番号と全体のステージ数を比較
        if (stageIndex != sceneName.STAGE_NAMES.Length - 1 )
        {
            // 異なる、つまり全てのステージをクリアしていない場合

            // 次のシーンに遷移する
            SceneManager.LoadScene(sceneName.STAGE_NAMES[stageIndex + 1]);
        }
        else
        {
            // 等しい、つまりすべてのステージをクリアした場合

            // 全敵キャラを殺したかチェック
            if(ResultPanelController.EnemyKillCount >= Constance.ALL_ENEMY_COUNT)
            {
                // 殺した場合

                // 隠しステージに遷移する
                SceneManager.LoadScene(SceneName.HIDDEN_STAGE_SCENE);
            }
            else
            {
                // 殺してない場合

                // 通常エンディングに移行する
                SceneManager.LoadScene(SceneName.ENDING_SCENE);
            }
        }
    }
}