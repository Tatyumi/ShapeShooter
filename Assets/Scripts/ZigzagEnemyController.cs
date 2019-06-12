using Common;
using UnityEngine;

public sealed class ZigzagEnemyController : EnemyController
{
    /// <summary>最小x座標</summary>
    private float minPosX;
    /// <summary>最大x座標</summary>
    private float maxPosX;
    /// <summary>左右に動く速度</summary>
    private float zigzagSpeed = 0.1f;

    private void Start()
    {
        // 初期化
        base.Initialize();

        // ステージの横幅(半分)を取得
        var stageHalfWidth = Constans.FIRST_STAGE_PART_WIDTH / 2;

        // 可動範囲
        var moveRange = stageHalfWidth - transform.localScale.x;

        // ラジアン
        var radian = transform.localRotation.z * Mathf.Deg2Rad;

        // 角度を考慮した最小、最大x座標を取得
        minPosX = transform.position.x - (moveRange * Mathf.Cos(radian));
        maxPosX = transform.position.x + (moveRange * Mathf.Cos(radian));
    }

    /// <summary>
    /// 左右に揺れながら移動する
    /// </summary>
    protected override void Move()
    {
        // 移動
        transform.Translate(zigzagSpeed, 0, moveSpeed);

        // 最大または最小のx座標に達した場合
        if (transform.localPosition.x > maxPosX || transform.localPosition.x < minPosX)
        {
            // 動きを反転させる
            zigzagSpeed *= -1;
        }
    }
}
