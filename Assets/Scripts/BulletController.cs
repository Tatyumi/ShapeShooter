using UnityEngine;

public sealed class BulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>弾速</summary>
    private float speed = 1.0f;
    /// <summary>生存時間</summary>
    private float lifeTime = 4.0f;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 奥に移動
        transform.Translate(0, 0, speed);

        // 計測時間が破棄時間に達した場合
        if (delta > lifeTime)
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

            // ダメージ適用処理
            enemy.ApplyDamage();
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
