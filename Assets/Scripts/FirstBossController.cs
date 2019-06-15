using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : EnemyController
{
    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(moveSpeed, moveSpeed, 0);
    }
}
