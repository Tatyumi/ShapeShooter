using UnityEngine;

public sealed class BulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>弾速</summary>
    private float speed = 1.0f;
    /// <summary>破棄時間</summary>
    private float deletTime = 4.0f;
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
        if (delta > deletTime)
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
        var obj = collision.gameObject.GetComponent<EnemyController>();

        // 存在チェック
        if (obj != null)
        {
            // ダメージ適用処理
            obj.ApplyDamage();
        }

        // パーティクルシステムを起動
        BulletDestroiedLightController.PlayLight(this.transform.position);

        // 破棄
        Destroy(gameObject);
    }
}
