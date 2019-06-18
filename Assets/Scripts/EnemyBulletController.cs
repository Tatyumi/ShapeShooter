using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>敵の弾情報</summary>
    public BulletData EnemyBulletData;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;

    void Awake()
    {
        // 全音楽データの取得
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 奥に移動
        transform.Translate(0, 0, EnemyBulletData.Speed);

        // 計測時間が破棄時間に達した場合
        if (delta > EnemyBulletData.LifeTime)
        {
            // 破棄
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 弾衝突処理
    /// </summary>
    public virtual void ConflictBullet()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.DestroySE.name);

        // 破棄
        Destroy(gameObject);
    }
}
