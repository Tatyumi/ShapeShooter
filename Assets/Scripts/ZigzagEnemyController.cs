using UnityEngine;

public sealed class ZigzagEnemyController : EnemyController
{
    public GameObject targetObject { get; set; }
    /// <summary>左右に動く速度</summary>
    private float zigzagSpeed = 0.1f;
    /// <summary>中心座標</summary>
    private Vector2 oPos;
    /// <summary>面積</summary>
    private float area;

    private void Start()
    {
        // 初期化
        base.Initialize();

        // 中心座標取得
        oPos = transform.position;

        // ステージの横幅(半分)を取得
        var radius = (targetObject.transform.localScale.x / 2) - (transform.localScale.x / 2);

        // 面積を算出
        area = radius * radius;
    }

    /// <summary>
    /// 左右に揺れながら移動する
    /// </summary>
    protected override void Move()
    {
        // 移動
        transform.Translate(zigzagSpeed, 0, moveSpeed);

        // 中心座標から現在の座標の距離を取得
        var pointPos = (transform.position.x - oPos.x) * (transform.position.x - oPos.x)
            + (transform.position.y - oPos.y) * (transform.position.y - oPos.y);

        // 面積外の座標か判別
        if (pointPos > area)
        {
            // 面積外の場合

            // 動きを反転させる
            zigzagSpeed *= -1;
        }
    }
}
