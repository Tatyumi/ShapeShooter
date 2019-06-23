﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public sealed class FirstStageEnemyGenerator : EnemyGenerator
{
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

    private void Start()
    {
        // コルーチンの取得
        corutine = StartGenerat();

        // 処理開始
        StartCoroutine(corutine);
    }

    protected override IEnumerator StartGenerat()
    {
        // 次のフェイズまでの待機時間
        var nextPhase = new WaitForSeconds(3.5f);
        // 待機時間
        var wait = new WaitForSeconds(1);
        // 連続して生成する回数
        var consecutivelyGeneratCount = 3;

        // 待機
        yield return nextPhase;

        // 左下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
            yield return wait;
        }

        // 右下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;

        // 左下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;

        // 左上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;

        // 右上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;

        // 右下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 左上に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
            yield return wait;
        }

        // 上に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 右上,右下に生成に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);

        // 待機
        yield return nextPhase;

        // 左上,左下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);

        // 待機
        yield return nextPhase;

        // 上、左上、右上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 下、左下、右下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 2週順に敵を生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 下に10体生成
        for (int i = 0; i < 10; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 中ボスを有効にする
        MiddelBoss.GetComponent<FirstMiddleBossController>().enabled = true;

        // 終了
        yield return null;
    }
}
