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
    /// <summary>生成座標</summary>
    private Vector3 generatVector;
    /// <summary>各生成座標</summary>
    private Vector3[] generatVectors;
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

                //gameObject.transform.rotation = item.Value.transform.rotation;

                //ステージ端にゲームオブジェクトを配置
                //gameObject.transform.localPosition = generatVectors[item.Index];

                //gameObject.transform.SetParent(item.Value.transform, false);

                // ゲームオブジェクトを指定の座標に配置
                gameObject.transform.SetPositionAndRotation(item.position, item.rotation);
                //gameObject.transform.localPosition = new Vector3(0, 1, 0.5f);
            }


            //生成するプレファブをゲームオブジェクトに変換
            //var gameObject = Instantiate(EnemyPrefab) as GameObject;

            //ゲームオブジェクトをPauseManagerの子にする
            //gameObject.transform.SetParent(PauseManager.transform, false);


            //ステージ端にゲームオブジェクトを生成
            //gameObject.transform.SetPositionAndRotation(StagePart.transform.position, StagePart.transform.rotation);

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

            //ステージのY,Zスケールを取得
            //var stageLocalScaleYZ =
            // new Vector3(0, 0, StagePart.transform.localScale.z / 2);
            // var stageLocalScaleYZ = StagePart.transform.localScale / 2;

            // ステージの一番端の座標を取得
            //generatVector = StagePart.transform.position + stageLocalScaleYZ;
            //generatVector = StagePart.transform.localPosition;

            //quaternion = StagePart.transform.rotation;

            //// ステージ数の配列の長さを確保
            //generatVectors = new Vector3[StageParts.Length];


            //// 各パーツを取得
            //foreach (var item in GeneratSpots.Select((Value, Index) => new { Value, Index }))
            //{
            //    ステージのY,Zスケールを取得
            //   var stageLocalScaleYZ = new Vector3(0, item.Value.transform.localScale.y / 2, item.Value.transform.localScale.z / 2);
            //    var stageLocalScaleYZ = new Vector3(0, 0, item.Value.transform.localScale.z / 2);

            //    ステージの一番端の座標を取得
            //   generatVectors[item.Index] = item.Value.transform.localPosition + stageLocalScaleYZ;
            //    generatVectors[item.Index] = item.Value.transform.localPosition;
            //    Debug.Log(item.Index + "番目本家" + item.Value.transform.localPosition);

            //    Debug.Log(item.Index + "番目" + generatVectors[item.Index]);
            //}
        }
}
