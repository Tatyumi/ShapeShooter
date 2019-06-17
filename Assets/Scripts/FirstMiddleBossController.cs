using UnityEngine;

public class FirstMiddleBossController : EnemyController
{
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>発光画像</summary>
    public GameObject WhiteLightImage;
    /// <summary>ジェネレーター</summary>
    public GameObject MiddleBossBulletGenerator;
    /// <summary>回転速度</summary>
    private float rotateSpeed = 1.0f;
    /// <summary>戦闘フラグ</summary>
    public bool isBattle;
    /// <summary>降下停止z座標</summary>
    private float stopPositionZ;
    /// <summary>降下速度</summary>
    private float fallSpeed = -0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        // 初期化
        base.Initialize();

        // 初期位置に配置
        transform.localPosition = new Vector3(Stage.transform.position.x, 8.0f, 12.0f);

        // プレイヤーのz座標を取得
        stopPositionZ = Player.transform.localPosition.z;

        // フラグ更新
        isBattle = false;
        enabled = false;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(0, rotateSpeed, 0);

        // フラグチェック
        if (isBattle)
        {
            // trueの場合

            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(Stage.transform.position, Vector3.forward, moveSpeed);
        }
        else
        {
            // falseの場合

            // 座標に達しているか判別
            if (transform.localPosition.y >= stopPositionZ)
            {
                //　下方向に移動
                transform.Translate(0, fallSpeed, 0);
            }
            else
            {
                // バトルフラグ更新
                isBattle = true;
            }
        }

    }

    /// <summary>
    /// 破壊された後
    /// </summary>
    private void OnDestroy()
    {
        // nullチェック
        if(MiddleBossBulletGenerator != null)
        {
            // nullでない場合

            // ジェネレータを無効にする
            MiddleBossBulletGenerator.GetComponent<FirstMibbleBossBulletGenerator>().enabled = false;
        }

        // nullチェック
        if (WhiteLightImage != null)
        {
            // nullではない場合

            // 発光画像の表示を行う
            WhiteLightImage.SetActive(true);
        }
    }
}
