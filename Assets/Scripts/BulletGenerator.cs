using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class BulletGenerator : MonoBehaviour
{
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>弾</summary>
    public GameObject BulletPrefab;
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>生成間隔</summary>
    private float span　= 0.5f;
    /// <summary>計測時間</summary>
    private float delta　= 0.0f;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>弾発生座標とプレイヤーまでの距離</summary>
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
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
                // SEの再生
                audioManager.PlaySE(audioManager.BulletSE.name);

                // 生成するプレファブをゲームオブジェクトに変換
                GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

                // ゲームオブジェクトをPauseManagerの子にする
                gameObject.transform.SetParent(PauseManager.transform, false);

                // プレイヤーの座標から指定の距離をとった座標にゲームオブジェクトを配置
                gameObject.transform.position = Player.transform.position + offset;

                // 初期化
                delta = 0.0f;
            }
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;

        // プレイヤーのZスケールと弾のZスケールの合計値を距離として取得
        offset = new Vector3(0, 0, Player.transform.localScale.z + BulletPrefab.transform.localScale.z);
    }

}
