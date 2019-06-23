using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageEnemyGenerator : EnemyGenerator
{
    /// <summary>生成場所番号</summary>
    private enum GeneratSpot
    {
        None = -1,
        Bottom,
        Top,
        Left,
        Right
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

        // 下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        // 左に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;
        // 上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        // 右に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Right);

        // 待機
        yield return nextPhase;

        // 左に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;
        // 上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        // 右に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Right);
        yield return wait;
        // 下に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);

        // 待機
        yield return nextPhase;

        // 下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 左に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Left);
            yield return wait;
        }

        // 上に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
            yield return wait;
        }

        // 右に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Right);
            yield return wait;
        }

        // 下に生成
        GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 下に生成
        GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        // 右に生成
        GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Right);
        yield return wait;
        // 上に生成
        GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        // 左に生成
        GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 左に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;
        // 上に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        // 右に生成
        GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Right);
        yield return wait;

        // 下5体生成
        for (int i = 0; i < 5; i++)
        {
            GeneratEnemy(StandardEnemyPrefab, (int)GeneratSpot.Top);
            yield return wait;
        }

        // 上に10体生成
        for (int i = 0; i < 10; i++)
        {
            GeneratZigzagEnemy(ZigzagdEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 中ボスを有効にする
        MiddelBoss.GetComponent<SecondMiddleBossController>().enabled = true;

        // 終了
        yield return null;
    }
}
