using UnityEngine;

public sealed class FirstBossController : EnemyController
{
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>ジェネレーター</summary>
    public EnemyBulletGenerator EnemyBulletGenerator;
    /// <summary>リザルトパネル</summary>
    public GameObject ResultPanel;

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(moveSpeed, moveSpeed, 0);
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

            // 音楽の停止
            audioManager.StopSound();

            // ボスの位置にパーティクルシステムを配置
            DestroyDirection.transform.position = transform.position;

            // パーティクルシステムを再生
            DestroyDirection.Play();

            // 破壊SE再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // nullチェック
            if (EnemyBulletGenerator != null)
            {
                // nullでない場合

                // ジェネレータを無効にする
                EnemyBulletGenerator.GetComponent<EnemyBulletGenerator>().enabled = false;
            }

            // リザルトパネルを表示する
            ResultPanel.SetActive(true);

            // オブジェクトを無効にする
            enabled = false;
            gameObject.SetActive(false);
        }

        return hp <= 0;
    }
}
