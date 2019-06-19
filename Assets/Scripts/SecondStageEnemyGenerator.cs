using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageEnemyGenerator : EnemyGenerator
{
    /// <summary>スタンダードエネミーのプレファブ</summary>
    public GameObject StandardEnemyPrefab;
    /// <summary>ジグザグエネミーのプレファブ</summary>
    public GameObject ZigzagdEnemyPrefab;
    /// <summary>中ボス</summary>
    public GameObject MiddelBoss;

    /// <summary>生成場所番号</summary>
    private enum GeneratSpot
    {
        None = -1,
        Bottom,
        Left,
        Right,
        Top
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

        GeneratEnemyObj(ZigzagdEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        GeneratEnemyObj(ZigzagdEnemyPrefab, (int)GeneratSpot.Right);
        yield return wait;
        GeneratEnemyObj(ZigzagdEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        GeneratEnemyObj(ZigzagdEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Left);
        yield return wait;

        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Right);
        yield return wait;

        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;


        // 下に10体生成
        for (int i = 0; i < 10; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
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
