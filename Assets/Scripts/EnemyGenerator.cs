using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // ステージのパーツ
    public GameObject StagePart;
    // 各生成場所
    public Transform[] EnemyGeneratSpots;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected void Initialize()
    {
        // 要素数分配列数を確保
        EnemyGeneratSpots = new Transform[transform.childCount];

        // 子要素の生成場所を配列で取得
        EnemyGeneratSpots = gameObject.GetComponentsInChildrenWithoutSelf<Transform>();
    }

    /// <summary>
    /// 指定した場所から敵キャラを生成する
    /// </summary>
    /// <param name="enemyPrefab">敵キャラオブジェクト</param>
    /// <param name="spotNum">生成場所番号</param>
    protected void GeneratEnemyObj(GameObject enemyPrefab,int spotNum)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var gameObject = Instantiate(enemyPrefab) as GameObject;

        //ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // ゲームオブジェクトを指定の座標に配置
        gameObject.transform.SetPositionAndRotation(EnemyGeneratSpots[spotNum].position, EnemyGeneratSpots[spotNum].rotation);
    }
}
