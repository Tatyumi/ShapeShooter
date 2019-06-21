using UnityEngine;

public class BarrierController : EnemyController
{
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 体力の取得
        hp = EnemyData.Hp;
    }

    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public override bool ApplyDamage()
    {
        // 体力を1減らす 
        hp -= 1;

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

            // 破棄する
            Destroy(gameObject);
        }
        else
        {
            // hpが1以上の場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }

        return false;
    }
}
