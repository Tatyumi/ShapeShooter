using UnityEngine;

public class AroundEnemyController : EnemyController
{
    /// <summary>対象座標</summary>
    public Vector3 targetVec { get; set; }

    /// <summary>
    /// 左右に揺れながら移動する
    /// </summary>
    protected override void Move()
    {
        // 移動
        transform.Translate(0, 0, moveSpeed);

        // 対象オブジェクトの座標を中心に右に回転
        transform.RotateAround(targetVec, Vector3.forward, moveSpeed * 5);
    }
}