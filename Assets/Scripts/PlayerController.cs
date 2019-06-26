using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>破壊演出</summary>
    public ParticleSystem DestroyDirection;
    /// <summary>ライフカウントテキスト</summary>
    public GameObject LifeCountText;
    /// <summary>死亡フラグ</summary>
    public static bool IsDie;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>ライフコントローラー</summary>
    private LifeCountTextController lifeController;

    private void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // ライフコントローラーコンポーネントを取得
        lifeController = LifeCountText.GetComponent<LifeCountTextController>();

        // 初期化
        IsDie = false;
    }


    // 衝突処理
    private void OnCollisionEnter()
    {
        // 死亡フラグ更新
        IsDie = true;

        // プレイヤーの位置にパーティクルシステムを配置
        DestroyDirection.transform.position = transform.position;

        // パーティクルシステムを再生
        DestroyDirection.Play();

        // 効果音再生
        audioManager.PlaySE(audioManager.PlayerDestroySE.name);

        // プレイヤーを消滅
        Destroy(gameObject);

        // 残機を減らす
        lifeController.ReduceLifeCount();
    }
}
