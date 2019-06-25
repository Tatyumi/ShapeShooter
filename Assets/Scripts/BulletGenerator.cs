using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>弾</summary>
    public GameObject BulletPrefab;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>弾発生座標とプレイヤーまでの距離</summary>
    protected Vector3 offset;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;
    /// <summary>生成間隔</summary>
    private float span = 0.5f;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 一定時間経過したか判別
        if (delta > span)
        {
            // スペースキーを押した場合
            if (Input.GetKey(KeyCode.Space))
            {
                // 生成
                Generat();

                // 初期化
                delta = 0.0f;
            }
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // プレイヤーのZスケールと弾のZスケールの合計値を距離として取得
        offset = new Vector3(0, 0, Player.transform.localScale.z + BulletPrefab.transform.localScale.z);
    }

    /// <summary>
    /// 生成する
    /// </summary>
    protected virtual void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BulletSE.name);

        // 生成するプレファブをゲームオブジェクトに変換
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // プレイヤーの座標から指定の距離をとった座標にゲームオブジェクトを配置
        gameObject.transform.position = Player.transform.position + offset;
    }
}
