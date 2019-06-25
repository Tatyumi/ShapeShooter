using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;

public abstract class EnemyGenerator : MonoBehaviour
{
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>ステージパーツ</summary>
    public GameObject StagePart;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>スタンダードエネミーのプレファブ</summary>
    public GameObject StandardEnemyPrefab;
    /// <summary>ジグザグエネミーのプレファブ</summary>
    public GameObject ZigzagdEnemyPrefab;
    /// <summary>回転エネミーのプレファブ</summary>
    public GameObject AroundEnemyPrefab;
    /// <summary>中ボス</summary>
    public GameObject MiddelBoss;
    /// <summary>各生成場所</summary>
    private Transform[] EnemyGeneratSpots;
    /// <summary>コルーチン</summary>
    protected IEnumerator corutine;

    // Start is called before the first frame update
    void Awake()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void Initialize()
    {
        // 要素数分配列数を確保
        EnemyGeneratSpots = new Transform[transform.childCount];

        // 子要素の生成場所を配列で取得
        EnemyGeneratSpots = gameObject.GetComponentsInChildrenWithoutSelf<Transform>();
    }

    private void Start()
    {
        // コルーチンの取得
        corutine = StartGenerat();

        // 処理開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 指定した場所から敵キャラを生成する
    /// </summary>
    /// <param name="spotNum">生成場所番号</param>
    protected void GeneratEnemy(int spotNum)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var gameObject = Instantiate(StandardEnemyPrefab) as GameObject;

        //ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // ゲームオブジェクトを指定の座標に配置
        gameObject.transform.SetPositionAndRotation(EnemyGeneratSpots[spotNum].position, EnemyGeneratSpots[spotNum].rotation);
    }

    /// <summary>
    /// 指定した場所から敵キャラを生成する
    /// </summary>
    /// <param name="spotNum">生成場所番号</param>
    protected void GeneratZigzagEnemy(int spotNum)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var gameObject = Instantiate(ZigzagdEnemyPrefab) as GameObject;

        // ジグザグする対象のオブジェクトを取得する
        gameObject.GetComponent<ZigzagEnemyController>().targetObject = StagePart;

        //ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // ゲームオブジェクトを指定の座標に配置
        gameObject.transform.SetPositionAndRotation(EnemyGeneratSpots[spotNum].position, EnemyGeneratSpots[spotNum].rotation);
    }

    /// <summary>
    /// 指定した場所から敵キャラを生成する
    /// </summary>
    /// <param name="spotNum">生成場所番号</param>
    protected void GeneratAroundEnemy(int spotNum)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var gameObject = Instantiate(AroundEnemyPrefab) as GameObject;

        // ジグザグする対象のオブジェクトを取得する
        gameObject.GetComponent<AroundEnemyController>().targetVec = Stage.transform.position;

        //ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // ゲームオブジェクトを指定の座標に配置
        gameObject.transform.SetPositionAndRotation(EnemyGeneratSpots[spotNum].position, EnemyGeneratSpots[spotNum].rotation);
    }

    /// <summary>
    /// コルーチン停止
    /// </summary>
    public void Stop()
    {
        StopCoroutine(corutine);
    }

    /// <summary>
    /// コルーチン再開
    /// </summary>
    public void Restart()
    {
        StartCoroutine(corutine);
    }

    // 生成開始処理
    protected abstract IEnumerator StartGenerat();
}
