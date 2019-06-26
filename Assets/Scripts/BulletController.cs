using UnityEngine;

public sealed class BulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>バレットデータ</summary>
    public BulletData BulletData;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;
    private AudioManager audioManager;

    private void Awake()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 奥に移動
        transform.Translate(0, 0, BulletData.Speed);

        // 計測時間が破棄時間に達した場合
        if (delta > BulletData.LifeTime)
        {
            // 破棄
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのEnemyControllerコンポーネントを取得
        var enemy = collision.gameObject.GetComponent<EnemyController>();

        // nullチェック
        if (enemy != null)
        {
            // nullではない場合

            // Hpを1減らす
            enemy.EnemyData.Hp -= 1;

            // hpが0以下か判別
            if (enemy.CheckHp())
            {
                // 0以下の場合

                // スコア加算
                ScoreController.AddScore(enemy.EnemyData.Score);

                // 撃破数を加算
                ResultPanelController.TempEnemyKillCount++;
            }
            else
            {
                // 1以上の場合

                // ダメージSEを再生
                audioManager.PlaySE(audioManager.DamageSE.name);
            }
        }
        else
        {
            // nullの場合

            // 衝突したオブジェクトのEnemyControllerコンポーネントを取得
            var enemyBullet = collision.gameObject.GetComponent<EnemyBulletController>();

            // nullチェック
            if(enemyBullet != null)
            {
                // nullではない場合

                // 弾衝突処理
                enemyBullet.ConflictBullet();
            }
        }

        // パーティクルシステムを起動
        BulletDestroiedLightController.PlayLight(this.transform.position);

        // 破棄
        Destroy(gameObject);
    }
}
