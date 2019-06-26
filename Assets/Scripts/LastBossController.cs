using UnityEngine;

public sealed class LastBossController : EnemyController
{
    /// <summary>終了フラグ</summary>
    public static bool isEnd = false;
    /// <summary>弾生成オブジェクト</summary>
    public GameObject BulletGenerator;
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>エンドメッセージパネル</summary>
    public GameObject EndMessagePanel;
    /// <summary>初期位置</summary>
    private Vector3 startPos = new Vector3(-1, 60, 20.8f);
    /// <summary>落下速度</summary>
    private const float fallSpeed = 0.1f;
    /// <summary>戦闘開始ポジション</summary>
    private const float battleStartPos = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // 動く
        Move();

        // 一定座標に達したか判別
        if (transform.localPosition.y <= battleStartPos)
        {
            // 達した場合

            // 弾生成オブジェクトを有効にする
            BulletGenerator.SetActive(true);
        }
        else
        {
            // 達していない場合

            // 下降する
            transform.localPosition =
                new Vector3(transform.localPosition.x, transform.localPosition.y - fallSpeed, transform.localPosition.z);
        }
    }

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

        // 初期位置の代入
        transform.localPosition = startPos;

        BulletGenerator.SetActive(false);
    }


    /// <summary>
    /// 動作
    /// </summary>
    protected override void Move()
    {
        // 回転
        transform.Rotate(0, moveSpeed, moveSpeed);
    }

    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public override bool ApplyDamage()
    {
        // 体力を1減らす 
        hp -= 1;

        // hpチェック
        if (hp <= 0 && isEnd)
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

            // 表示
            EndMessagePanel.SetActive(true);

            // 破棄する
            Destroy(gameObject);
        }

        return hp <= 0;
    }
}
