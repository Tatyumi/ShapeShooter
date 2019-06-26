using UnityEngine;

public class BarrierController : EnemyController
{
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>ボス</summary>
    public EnemyController Boss;
    /// <summary>エネミーバレットジェネレーター</summary>
    public EnemyBulletGenerator BossBulletGenerator;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 体力の取得
        hp = EnemyData.Hp;

        // 移動速度の取得
        moveSpeed = EnemyData.MoveSpeed * -1;

        // ボス、バレットジェネレーターを無効にする
        Boss.enabled = false;
        BossBulletGenerator.enabled = false;
    }

    /// <summary>
    /// 体力チェック
    /// </summary>
    public override bool CheckHp()
    {
        // hpチェック
        if (hp <= 0)
        {
            // hpが0以下の場合

            // 破壊SE再生
            audioManager.PlaySE(audioManager.BreakBarrierSE.name);

            // バリアの位置にパーティクルシステムを配置
            DestroyDirection.transform.localPosition = transform.localPosition;

            // パーティクルシステムを再生
            DestroyDirection.Play();

            // ボス、バレットジェネレーターを有効にする
            Boss.enabled = true;
            BossBulletGenerator.enabled = true;

            // 破棄する
            Destroy(gameObject);
        }

        return false;
    }
}
