using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStageEnemyGenerator : EnemyGenerator
{
    /// <summary>生成場所番号</summary>
    private enum GeneratSpot
    {
        None = -1,
        Bottom,
        Top,
        BottomLeft,
        Left,
        TopLeft,
        TopRight,
        Right,
        BottomRight
    }

    /// <summary>
    /// 敵キャラ生成コルーチン
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator StartGenerat()
    {
        // 次のフェイズまでの待機時間
        var nextPhaseWait = new WaitForSeconds(3.5f);

        // 中ボスフェイズまでの待機時間
        var middleBossPhaseWait = new WaitForSeconds(8.0f);

        // 待機時間
        var wait = new WaitForSeconds(1);

        // 待機
        yield return nextPhaseWait;

        // 下に生成
        GeneratEnemy((int)GeneratSpot.Bottom);
        yield return wait;
        // 左下に生成
        GeneratEnemy((int)GeneratSpot.BottomLeft);
        yield return wait;
        // 左に生成
        GeneratEnemy((int)GeneratSpot.Left);
        yield return wait;
        // 左下に生成
        GeneratEnemy((int)GeneratSpot.BottomLeft);
        yield return wait;
        // 下に生成
        GeneratEnemy((int)GeneratSpot.Bottom);
        yield return wait;
        // 右下に生成
        GeneratEnemy((int)GeneratSpot.BottomRight);
        yield return wait;
        // 上に生成
        GeneratEnemy((int)GeneratSpot.Top);
        yield return wait;
        // 右に生成
        GeneratEnemy((int)GeneratSpot.Right);

        // 待機
        yield return nextPhaseWait;

        // 上に生成
        GeneratAroundEnemy((int)GeneratSpot.Top);
        yield return wait;
        // 左上に生成
        GeneratAroundEnemy((int)GeneratSpot.TopLeft);
        yield return wait;
        // 左に生成
        GeneratAroundEnemy((int)GeneratSpot.Left);
        yield return wait;
        // 左下に生成
        GeneratAroundEnemy((int)GeneratSpot.BottomLeft);
        yield return wait;

        // 待機
        yield return nextPhaseWait;

        // 下に生成
        GeneratZigzagEnemy((int)GeneratSpot.Bottom);
        yield return wait;
        // 左に生成
        GeneratZigzagEnemy((int)GeneratSpot.Left);
        yield return wait;
        // 上に生成
        GeneratZigzagEnemy((int)GeneratSpot.Top);
        yield return wait;
        // 右に生成
        GeneratZigzagEnemy((int)GeneratSpot.Right);
        yield return wait;

        // 待機
        yield return nextPhaseWait;

        // 右に生成
        GeneratAroundEnemy((int)GeneratSpot.Right);
        yield return wait;
        // 左に生成
        GeneratAroundEnemy((int)GeneratSpot.TopRight);
        yield return wait;
        // 上に生成
        GeneratAroundEnemy((int)GeneratSpot.Top);
        yield return wait;
        // 左上に生成
        GeneratAroundEnemy((int)GeneratSpot.TopLeft);
        yield return wait;

        // 待機
        yield return nextPhaseWait;

        // 上に生成
        GeneratEnemy((int)GeneratSpot.Top);
        yield return wait;
        // 左上に生成
        GeneratEnemy((int)GeneratSpot.TopLeft);
        yield return wait;
        // 左に生成
        GeneratEnemy((int)GeneratSpot.Left);
        yield return wait;
        // 左下に生成
        GeneratEnemy((int)GeneratSpot.BottomLeft);
        yield return wait;
        // 下に生成
        GeneratEnemy((int)GeneratSpot.Bottom);
        yield return wait;
        // 右下に生成
        GeneratEnemy((int)GeneratSpot.BottomRight);
        yield return wait;
        // 右に生成
        GeneratEnemy((int)GeneratSpot.Right);
        yield return wait;
        // 右上に生成
        GeneratEnemy((int)GeneratSpot.TopRight);
        yield return wait;
        // 上に生成
        GeneratEnemy((int)GeneratSpot.Top);
        yield return wait;

        // 待機
        yield return nextPhaseWait;

        // 下に2体生成
        for (int i = 0; i < 2; i++)
        {
            GeneratZigzagEnemy((int)GeneratSpot.Bottom);
            yield return wait;
        }

        // 右に2体生成
        for (int i = 0; i < 2; i++)
        {
            GeneratZigzagEnemy((int)GeneratSpot.Right);
            yield return wait;
        }

        // 上に2体生成
        for (int i = 0; i < 2; i++)
        {
            GeneratZigzagEnemy((int)GeneratSpot.Top);
            yield return wait;
        }

        // 左に2体生成
        for (int i = 0; i < 2; i++)
        {
            GeneratZigzagEnemy((int)GeneratSpot.Left);
            yield return wait;
        }

        // 待機
        yield return nextPhaseWait;

        // 右下に生成
        GeneratAroundEnemy((int)GeneratSpot.BottomRight);
        // 右に生成
        GeneratAroundEnemy((int)GeneratSpot.Right);
        // 右上に生成
        GeneratAroundEnemy((int)GeneratSpot.TopRight);
        // 上に生成
        GeneratAroundEnemy((int)GeneratSpot.Top);
        // 左上に生成
        GeneratAroundEnemy((int)GeneratSpot.TopLeft);
        // 左に生成
        GeneratAroundEnemy((int)GeneratSpot.Left);
        // 左下に生成
        GeneratAroundEnemy((int)GeneratSpot.BottomLeft);
        // 下に生成
        GeneratAroundEnemy((int)GeneratSpot.Bottom);
        yield return wait;

        // 待機
        yield return middleBossPhaseWait;

        // 中ボスを有効にする
        MiddelBoss.SetActive(true);
        MiddelBoss.GetComponent<EnemyController>().enabled = true;

        // 終了
        yield return null;
    }
}
