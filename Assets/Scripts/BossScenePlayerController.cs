﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerController : MonoBehaviour
{/// <summary>ボス</summary>
    public GameObject Boss;
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>移動速度</summary>
    public float MoveSpeed = 1.3f;
    /// <summary>ライフカウントテキスト</summary>
    public GameObject LifeCountText;
    /// <summary>死亡フラグ</summary>
    public static bool IsDie;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>ライフコントローラー</summary>
    private LifeCountTextController lifeController;

    private void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 回転処理
        transform.Rotate(0, MoveSpeed, 0);

        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ボス座標を中心に右に回転
            transform.RotateAround(Boss.transform.position, Vector3.forward, MoveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ボス座標を中心に左に回転
            transform.RotateAround(Boss.transform.position, Vector3.forward, MoveSpeed * -1);
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // ライフコントローラーコンポーネントを取得
        lifeController = LifeCountText.GetComponent<LifeCountTextController>();

        // 初期化
        IsDie = false;
    }

    // 衝突処理
    private void OnCollisionEnter(Collision collision)
    {
        // 死亡フラグ更新
        IsDie = true;

        // プレイヤーの位置にパーティクルシステムを配置
        DestroyDirection.transform.localPosition = transform.localPosition;

        // パーティクルシステムを再生
        DestroyDirection.Play();

        // 効果音再生
        audioManager.PlaySE(audioManager.PlayerDestroySE.name);

        // プレイヤーを消滅
        Destroy(gameObject);

        // 残機を減らす
        lifeController.ReduceLifeCount();
    }
}