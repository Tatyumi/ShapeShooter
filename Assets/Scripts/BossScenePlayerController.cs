using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BossScenePlayerController : PlayerController
{
    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.down, MoveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 対象オブジェクトの座標を中心に左に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.up, MoveSpeed);
        }
    }
}