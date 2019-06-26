using System.Collections;
using UnityEngine;

public class HiddenStageWallGenerator : WallGenerator
{
    /// <summary>白光画像</summary>
    public GameObject WhiteLightImage;

    /// <summary>壁要素番号</summary>
    private enum WallIndex
    {
        None = -1,
        Vertical,
        Horizon,
        DiagonalLeft,
        DiagonalRight,
        BigVertical,
        BigHorizon
    }

    /// <summary>
    /// 壁生成コルーチン
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator StartGenerat()
    {
        // オーディオマネージャーの取得
        var audioManager = AudioManager.Instance;

        // 次のフェイズまでの待機時間
        var nextPhaseWait = new WaitForSeconds(3.5f);

        // 待機時間
        var wait = new WaitForSeconds(1.7f);

        // 待機
        yield return nextPhaseWait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);

        // 待機
        yield return nextPhaseWait;

        // 横壁
        GeneratWall((int)WallIndex.Horizon);

        // 待機
        yield return nextPhaseWait;

        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);

        // 待機
        yield return nextPhaseWait;

        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);

        // 待機
        yield return nextPhaseWait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);

        // 待機
        yield return nextPhaseWait;

        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);

        // 待機
        yield return nextPhaseWait;

        // 大縦壁
        GeneratWall((int)WallIndex.BigVertical);

        // 待機
        yield return nextPhaseWait;

        // 大横壁
        GeneratWall((int)WallIndex.BigHorizon);

        // 待機
        yield return nextPhaseWait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        yield return wait;
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        yield return wait;
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 大縦壁
        GeneratWall((int)WallIndex.BigVertical);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;

        // 大横壁
        GeneratWall((int)WallIndex.BigHorizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 待機
        yield return nextPhaseWait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        yield return wait;

        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 大横壁
        GeneratWall((int)WallIndex.BigHorizon);
        yield return wait;

        // 大縦壁
        GeneratWall((int)WallIndex.BigVertical);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;

        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;

        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 横壁
        GeneratWall((int)WallIndex.Horizon);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // 縦壁
        GeneratWall((int)WallIndex.Vertical);
        // 左斜め壁
        GeneratWall((int)WallIndex.DiagonalLeft);
        // 右斜め壁
        GeneratWall((int)WallIndex.DiagonalRight);
        yield return wait;

        // BGMのフェードアウト
        audioManager.FadeOutBGM();
        // 画像の表示
        WhiteLightImage.SetActive(true);

        // 終了
        yield return null;
    }
}
