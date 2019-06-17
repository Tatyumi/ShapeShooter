﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>エネミーデータ</summary>
    public EnemyData EnemyData;
    /// <summary>体力</summary>
    protected int hp;
    /// <summary> 移動速度</summary>
    protected float moveSpeed;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;
    /// <summary>破棄を行うx座標</summary>
    private const float destroyPosx = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    void Update()
    {
        // 移動
        Move();

        // z座標チェック
        CheckPosZ(transform.position.z);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 体力の取得
        hp = EnemyData.Hp;

        // 移動速度の取得
        moveSpeed = EnemyData.MoveSpeed * -1;
    }

    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public virtual void ApplyDamage()
    {
        // 体力を1減らす 
        hp -= 1;

        // 体力が0以下の場合
        if (hp <= 0)
        {
            // 破壊SE再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // 破棄する
            Destroy(gameObject);
        }
        else
        {
            // 体力が残っている場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }
    }

    /// <summary>
    /// 移動する
    /// </summary>
    protected virtual void Move()
    {
        // 移動
        transform.Translate(0, 0, moveSpeed);
    }

    /// <summary>
    /// z座標の確認を行う
    /// </summary>
    protected void CheckPosZ(float posX)
    {
        // 指定のz座標を下回った場合
        if (posX < destroyPosx)
        {
            // 破棄する
            Destroy(gameObject);
        }
    }
}
