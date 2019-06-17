using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    /// <summary>弾が発する光</summary>
    public GameObject BulletLight;
    /// <summary>弾速</summary>
    private float speed = 0.2f;
    /// <summary>破棄時間</summary>
    private float deletTime = 3.0f;
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
        // 破棄
        Destroy(gameObject);
    }
}
