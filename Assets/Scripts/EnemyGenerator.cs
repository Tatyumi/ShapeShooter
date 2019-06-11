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
    /// <summary>敵キャラのプレファブ</summary>
    public GameObject EnemyPrefab;
    /// <summary>生成間隔</summary>
    private float span = 1.0f;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 一定時間経過したか判別
        if (delta > span)
        {
            foreach (var item in EnemyGeneratSpots)
            {
                //生成するプレファブをゲームオブジェクトに変換
                var gameObject = Instantiate(EnemyPrefab) as GameObject;

                //ゲームオブジェクトをPauseManagerの子にする
                gameObject.transform.SetParent(PauseManager.transform, false);

                // ゲームオブジェクトを指定の座標に配置
                gameObject.transform.SetPositionAndRotation(item.position, item.rotation);
            }

            // 初期化
            delta = 0.0f;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 要素数分配列数を確保
        EnemyGeneratSpots = new Transform[transform.childCount];

        // 子要素の生成場所を配列で取得
        EnemyGeneratSpots = gameObject.GetComponentsInChildrenWithoutSelf<Transform>();
    }
}
