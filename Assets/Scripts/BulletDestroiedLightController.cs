using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroiedLightController : MonoBehaviour
{
    /// <summary>弾衝突時演出の発光演出システム</summary>
    private static ParticleSystem bulletDestroiedLight;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // パーティクルシステムのコンポーネント取得
        bulletDestroiedLight = this.gameObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 指定した座標でパーティクスシステムを起動する
    /// </summary>
    /// <param name="playPos">発光するポジション1</param>
    public static void PlayLight(Vector3 playPos)
    {
        // 指定の座標に配置
        bulletDestroiedLight.transform.position = playPos;

        // 再生
        bulletDestroiedLight.Play();
    }
}
