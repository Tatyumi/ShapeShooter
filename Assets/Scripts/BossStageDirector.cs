using Common;
using UnityEngine;
using System;

public class BossStageDirector : StageDirector
{
    /// <summary>ボスオブジェクトリスト</summary>
    public GameObject BossLists;
    /// <summary>ボストランスフォームズ</summary>
    private Transform bossTransforms;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(StageBgmName);

        // フラグ初期化
        PauseManager.isPause = false;

        // BossListsの子要素をすべて取得
        bossTransforms = BossLists.GetComponentInChildren<Transform>();

        // インスタンス取得
        var sceneName = new SceneName();

        // 挑戦したステージ名からステージ名リストの要素番号を取得する
        var activeBossNumber= Array.IndexOf(sceneName.STAGE_NAMES, ChallengeStageName);

        // bossTransformsの子要素の有効、無効の切り替えを行う
        for (int i = 0; i < bossTransforms.childCount; i++)
        {
            // 該当するBossを有効にする
            bossTransforms.GetChild(i).gameObject.SetActive(activeBossNumber == i);
        }
    }
}