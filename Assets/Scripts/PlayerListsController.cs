using UnityEngine;

public class PlayerListsController : MonoBehaviour
{
    /// <summary>プレイヤーのレベル</summary>
    public static int PlayerLevel = 0;
    /// <summary>対象オブジェクト</summary>
    public GameObject TargetObj;
    /// <summary>移動速度</summary>
    public float MoveSpeed = 1.3f;
    /// <summary>プレイヤーリストの子要素</summary>
    private Transform playerListChildren;
    /// <summary>プレイヤーのフォーム</summary>
    private int playerForm = 0;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>最大レベル</summary>
    private static int maxLevel = 4;


    private void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 回転処理
        transform.Rotate(0, MoveSpeed, 0);

        // 移動
        Move();

        // Cを押した場合
        if (Input.GetKeyUp(KeyCode.C))
        {
            // フォーム変更
            CahngeForm();
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 音楽データ取得
        audioManager = AudioManager.Instance;

        // 子要素を取得
        playerListChildren = gameObject.GetComponentInChildren<Transform>();

        // 初期値代入
        playerForm = 0;

        // playerListChildrenの子要素の有効、無効の切り替えを行う
        for (int i = 0; i < playerListChildren.childCount; i++)
        {
            // 該当するBossを有効にする
            playerListChildren.GetChild(i).gameObject.SetActive(playerForm == i);
        }
    }


    /// <summary>
    /// 移動処理
    /// </summary>
    protected virtual void Move()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.forward, MoveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 対象オブジェクトの座標を中心に左に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.forward, MoveSpeed * -1);
        }
    }

    /// <summary>
    /// プレイヤーのフォームを変更する
    /// </summary>
    private void CahngeForm()
    {
        // プレイヤーレベルチェック
        if (PlayerLevel > 0)
        {
            // 0より大きい場合

            // SE再生
            audioManager.PlaySE(audioManager.ChaneFormSE.name);

            // 加算
            playerForm++;

            // レベルを超えているかチェック
            if (playerForm > PlayerLevel)
            {
                // 超えた場合

                // 初期値代入
                playerForm = 0;
            }

            // playerListChildrenの子要素の有効、無効の切り替えを行う
            for (int i = 0; i < playerListChildren.childCount; i++)
            {
                // 該当するBossを有効にする
                playerListChildren.GetChild(i).gameObject.SetActive(playerForm == i);
            }
        }
    }

    /// <summary>
    /// プレイヤーレベルアップ処理
    /// </summary>
    public static void LevelUp()
    {
        // プレイヤーレベルが最大か判別
        if(PlayerLevel <= maxLevel)
        {
            // 最大でない場合

            // 加算
            PlayerLevel++;
        }
    }
}
