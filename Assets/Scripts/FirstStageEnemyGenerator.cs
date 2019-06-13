using System.Collections;
using UnityEngine;
using Common;

public sealed class FirstStageEnemyGenerator : EnemyGenerator
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
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
            yield return wait;
        }

        // 右下に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 下に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;

        // 左下に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;

        // 左上に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 上に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;

        // 右上に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;

        // 右下に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 左上に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
            yield return wait;
        }

        // 上に３体生成
        for (int i = 0; i < consecutivelyGeneratCount; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 右上,右下に生成に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);

        // 待機
        yield return nextPhase;

        // 左上,左下に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);

        // 待機
        yield return nextPhase;

        // 上、左上、右上に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 下、左下、右下に生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 待機
        yield return nextPhase;

        // 2週順に敵を生成
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomLeft);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopLeft);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Top);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.TopRight);
        yield return wait;
        GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.BottomRight);
        yield return wait;

        // 下に10体生成
        for (int i = 0; i < 10; i++)
        {
            GeneratEnemyObj(StandardEnemyPrefab, (int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 待機
        yield return nextPhase;

        // 中ボスフェイズに移行
        Phase.IsMiddleBoss = true;

        // 終了
        yield return null;
    }
}
