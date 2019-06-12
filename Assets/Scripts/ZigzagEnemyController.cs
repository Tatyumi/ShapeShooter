using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ZigzagEnemyController : EnemyController
{
    // ステージの一部
    public GameObject StagePart;
    /// <summary>ステージの横幅</summary>
    private float stageWidth;

    private void Start()
    {
        // 初期化
        base.Initialize();

        // ステージの横幅を取得
        stageWidth = StagePart.transform.localScale.x;
    }


    private void Update()
    {
        // 移動
        Move();
    }

    /// <summary>
    /// 左右に揺れながら移動する
    /// </summary>
    protected override void Move()
    {
        // 左右に揺れながら移動
        transform.localPosition = new Vector3((transform.localPosition.x + Mathf.Sin(Time.time * stageWidth))/2　, transform.localPosition.y, transform.localPosition.z + moveSpeed);
    }


}
