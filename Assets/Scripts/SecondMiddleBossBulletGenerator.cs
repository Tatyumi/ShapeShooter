using UnityEngine;

public sealed class SecondMiddleBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>中ボス</summary>
    public GameObject MiddleBoss;
    /// <summary>弾発射位置</summary>
    public GameObject[] MiddleBossGeneratSpots;
    /// <summary>セカンドステージの中ボスコントローラー</summary>
    private MiddleBossController secondMiddle;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // コンポネントの取得
        secondMiddle = MiddleBoss.GetComponent<MiddleBossController>();
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // フラグチェック
        if (secondMiddle.isBattle)
        {
            // trueの場合

            // SEの再生
            audioManager.PlaySE(audioManager.BulletSE.name);

            // 生成オブジェクト格納配列
            GameObject[] gameObject = new GameObject[MiddleBossGeneratSpots.Length];

            // 生成数だけオブジェクトを生成
            for (int i = 0; i < MiddleBossGeneratSpots.Length; i++)
            {
                // ゲームオブジェクトを格納
                gameObject[i] = Instantiate(BulletPrefab) as GameObject;

                // ゲームオブジェクトをPauseManagerの子にする
                gameObject[i].transform.SetParent(PauseManager.transform, false);

                // 各生成位置に配置する
                gameObject[i].transform.position = MiddleBossGeneratSpots[i].transform.position;

                // プレイヤーの方向を向く
                gameObject[i].transform.eulerAngles += new Vector3(0,180,0);
            }
        }
    }
}
