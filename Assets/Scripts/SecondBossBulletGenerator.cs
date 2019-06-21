using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>ボス</summary>
    public GameObject Boss;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // 攻撃間隔の初期化
        span = 0.5f;

        // 無効にする
        enabled = false;
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BossBulletSE.name);

        // 生成オブジェクト格納配列
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // 中ボスの座標に配置する
        gameObject.transform.position = Boss.transform.position;

        // プレイヤーの方向を向く
        gameObject.transform.LookAt(Player.transform.position);
    }
}