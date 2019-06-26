using UnityEngine;

public sealed class FirstMibbleBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>中ボス</summary>
    public GameObject MiddleBoss;
    /// <summary>初期ステージのボスコントローラー</summary>
    private MiddleBossController firstMiddle;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // コンポネントの取得
        firstMiddle = MiddleBoss.GetComponent<MiddleBossController>();
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // フラグチェック
        if (firstMiddle.isBattle)
        {
            // trueの場合

            // SEの再生
            audioManager.PlaySE(audioManager.BulletSE.name);

            // 生成するプレファブをゲームオブジェクトに変換
            GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

            // ゲームオブジェクトをPauseManagerの子にする
            gameObject.transform.SetParent(PauseManager.transform, false);

            // 中ボスの座標に配置する
            gameObject.transform.position = MiddleBoss.transform.position;

            // プレイヤーの方向を向く
            gameObject.transform.LookAt(Player.transform.position);
        }
    }
}
