using UnityEngine;

sealed public class BulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>弾速</summary>
    private float speed = 1.0f;
    /// <summary>オブジェクトを破棄するZ座標</summary>
    private const float destroyPositionZ = 110.0f;

    // Update is called once per frame
    void Update()
    {
        // 奥に移動
        transform.Translate(0, 0, speed);

        // 一定の距離に達する
        if (transform.localPosition.z > destroyPositionZ)
        {
            // 破棄
            Destroy(gameObject);
        }
    }

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
