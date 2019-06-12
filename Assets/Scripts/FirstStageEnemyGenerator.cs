using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FirstStageEnemyGenerator : EnemyGenerator
{
    /// <summary>敵キャラのプレファブ</summary>
    public GameObject EnemyPrefab;
    /// <summary>生成間隔</summary>
    private float span = 2.0f;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;

    /// <summary>生成場所番号</summary>
    private enum GeneratSpot
    {
        None = -1,
        Bottom,
        BottomLeft,
        TopLeft,
        Top,
        TopRight,
        BottomRight
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 一定時間経過したか判別
        if (delta > span)
        {
            // 生成
            base.GeneratEnemyObj(EnemyPrefab, (int)GeneratSpot.Bottom);

            // 初期化
            delta = 0.0f;
        }
    }
}
