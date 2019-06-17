using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGenerator : MonoBehaviour
{
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>弾</summary>
    public GameObject BulletPrefab;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;
    /// <summary>生成間隔</summary>
    private float span = 1.0f;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 一定時間経過したか判別
        if (delta > span)
        {
            // 生成
            Generat();

            // 初期化
            delta = 0.0f;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected virtual void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BulletSE.name);

        // 生成するプレファブをゲームオブジェクトに変換
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // プレイヤーの方向を向く
        gameObject.transform.LookAt(Player.transform.position);
    }
}
