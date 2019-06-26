using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMiddleBossController : MiddleBossController
{
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>降下停止z座標</summary>
    private float stopPositionY;
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
        transform.localPosition = new Vector3(Stage.transform.position.x, 8.0f, 10.0f);

        // ステージのy座標を取得
        stopPositionY = Stage.transform.localPosition.y;

        // フラグ更新
        isBattle = false;
        enabled = false;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {

        // フラグチェック
        if (isBattle)
        {
            // trueの場合

            // 回転処理
            transform.eulerAngles += new Vector3(0, 0, moveSpeed);
        }
        else
        {
            // falseの場合

            // 座標に達しているか判別
            if (transform.localPosition.y >= stopPositionY)
            {
                //　下方向に移動
                transform.Translate(fallSpeed, 0, 0);
            }
            else
            {
                // バトルフラグ更新
                isBattle = true;
            }
        }
    }
}
