using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;

public abstract class EnemyGenerator : MonoBehaviour
{
    /// <summary>ステージパーツ</summary>
    public GameObject StagePart;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>経過時間</summary>
    protected float delta;
    /// <summary>ゲーム進捗度</summary>
    protected int phase;
    /// <summary>フェイズ開始時間</summary>
    protected int phaseStartTime;
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

        // ゲーム進捗初期化
        phase = 1;
        phaseStartTime = 3;
    }

    // 生成開始処理
    protected abstract IEnumerator StartGenerat();


    /// <summary>
    /// 指定した場所から敵キャラを生成する
    /// </summary>
    /// <param name="enemyPrefab">敵キャラオブジェクト</param>
    /// <param name="spotNum">生成場所番号</param>
    protected void GeneratEnemyObj(GameObject enemyPrefab, int spotNum)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var gameObject = Instantiate(enemyPrefab) as GameObject;

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
}
