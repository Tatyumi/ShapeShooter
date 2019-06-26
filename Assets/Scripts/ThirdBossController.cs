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

            // 音楽の停止
            audioManager.StopSound();

            // 破壊SEの再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // 撃破数を加算
            ResultPanelController.TempEnemyKillCount++;

            // プレイヤーレベル加算
            PlayerListsController.PlayerLevel++;

            // ボスの位置にパーティクルシステムを配置
            DestroyDirection.transform.position = transform.position;

            // パーティクルシステムを再生
            DestroyDirection.Play();

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
        else
        {
            // 1以上の場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }
    }
}