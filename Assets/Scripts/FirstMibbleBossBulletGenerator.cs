using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMibbleBossBulletGenerator : BulletGenerator
{
    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // 生成間隔を初期化
        span = 1.0f;
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BulletSE.name);

        // 生成するプレファブをゲームオブジェクトに変換
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // プレイヤーの方向を向く
        transform.LookAt(Player.transform.position);
    }
}
