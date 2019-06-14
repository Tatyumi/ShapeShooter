using Common;
using UnityEngine;

public class FirstMiddleBossController : EnemyController
{
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>回転速度</summary>
    private float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        base.Initialize();

        // 初期位置に配置
        transform.localPosition = new Vector3(Stage.transform.position.x, 8.0f, 3.4f);

        // 無効にする
        enabled = false;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(0, rotateSpeed, 0);

        // 座標に達しているか判別
        if (transform.localPosition.y >= -2.3f)
        {
            //　下方向に移動
            transform.Translate(0, moveSpeed, 0);
        }
    }
}
