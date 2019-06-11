using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    /// <summary>ステージのパーツ</summary>
    public GameObject[] StageParts;
    /// <summary>ステージトランスフォーム</summary>
    private Transform stage;

    /// <summary>部品番号</summary>
    private enum PartsNum
    {
        None = -1,
        Top,
        Bottom
    }

    // Start is called before the first frame update
    void Awake()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // ステージの座標を取得
        stage = this.transform;

        //ステージの中心座標を取得(ステージの上部、下部から算出)
        Vector2 stageCenterPos = Vector2.Lerp(StageParts[(int)PartsNum.Top].transform.localPosition, StageParts[(int)PartsNum.Bottom].transform.localPosition, 0.5f);

        //ステージの中心座標を代入
        stage.localPosition = stageCenterPos;

        //各ステージのパーツを子として取得する
        foreach(GameObject parts in StageParts)
        {
            parts.transform.parent = stage;
        }
    }
}
