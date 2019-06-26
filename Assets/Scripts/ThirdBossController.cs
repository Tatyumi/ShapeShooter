using UnityEngine;

public sealed class ThirdBossController : EnemyController
{
    /// <summary>ジェネレーター</summary>
    public EnemyBulletGenerator[] EnemyBulletGenerator;
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>リザルトパネル</summary>
    public GameObject ResultPanel;

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
        moveSpeed = EnemyData.MoveSpeed;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(moveSpeed, moveSpeed, 0.0f);
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

                // 全てのジェネレータを無効にする
                for (int i = 0; i > EnemyBulletGenerator.Length; i++)
                {
                    EnemyBulletGenerator[i].GetComponent<EnemyBulletGenerator>().enabled = false;
                }
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