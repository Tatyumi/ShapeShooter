using UnityEngine;

public sealed class BulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>バレットデータ</summary>
    public BulletData BulletData;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;
    /// <summary>ダメージ</summary>
    private int damage = 1;

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

            // ダメージ適応処理
            enemy.ApplyDamage(damage);
        }
        else
        {
            // nullの場合

            // 衝突したオブジェクトのEnemyControllerコンポーネントを取得
            var enemyBullet = collision.gameObject.GetComponent<EnemyBulletController>();

            // nullチェック
            if (enemyBullet != null)
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
