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
    /// ダメージ適応処理
    /// </summary>
    public override void ApplyDamage(int damage)
    {
        // ダメージ適応
        hp -= damage;

        // hpチェック
        if (hp <= 0)
        {
            // 0以下の場合

            // バリアの位置にパーティクルシステムを配置
            DestroyDirection.transform.localPosition = transform.localPosition;

            // パーティクルシステムを再生
            DestroyDirection.Play();

            // ボス、バレットジェネレーターを有効にする
            Boss.enabled = true;
            BossBulletGenerator.enabled = true;

            // 破壊SEの再生
            audioManager.PlaySE(audioManager.BreakBarrierSE.name);

            // 破棄する
            Destroy(gameObject);
        }
        else
        {
            // 1以上の場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }
    }
}
