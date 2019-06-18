using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ResultPanelController : MonoBehaviour
{
    /// <summary>敵キャラを殺した数</summary>
    public static int EnemyKillCount;
    /// <summary>敵キャラを殺した数の退避変数</summary>
    public static int TempEnemyKillCount;
    /// <summary>クリアメッセージ</summary>
    public GameObject ClearMessage;
    /// <summary>殺した敵キャラテキスト</summary>
    public GameObject KillEnemyText;
    /// <summary>殺した敵キャラの数テキスト</summary>
    public GameObject KillEnemyCountText;
    /// <summary>ガイドメッセージ</summary>
    public GameObject GuideMessage;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>リザルトフラグ</summary>
    private bool isResult;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    private void Update()
    {
        // オブジェクトの活性状態とフラグチェック
        if(gameObject.activeSelf && !isResult)
        {
            // オブジェクトが活性であり,かつフラグがfalseの場合

            // フラグ更新
            isResult = true;

            // リザルトコルーチンを開始する
            var corutine = StartResult();
            StartCoroutine(corutine);
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 非表示
        ClearMessage.SetActive(false);
        KillEnemyText.SetActive(false);
        KillEnemyCountText.SetActive(false);
        GuideMessage.SetActive(false);
        gameObject.SetActive(false);

        // 初期値代入
        isResult = false;

        // 音楽データの取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// リザルトコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartResult()
    {
        // 効果音の再生
        audioManager.PlaySE(audioManager.ResultSE.name);

        // ポーズ状態にして、操作負荷にする
        PauseManager.isPause = true;

        // 表示
        gameObject.SetActive(true);

        // 待機時間
        var wait = new WaitForSeconds(1.5f);

        // クリアメッセージの表示
        ClearMessage.SetActive(true);
        // 待機
        yield return wait;

        // 殺した敵キャラテキストの表示
        KillEnemyText.SetActive(true);
        // 待機
        yield return wait;

        // ステージで倒した敵キャラの数を取得
        KillEnemyCountText.GetComponent<Text>().text = TempEnemyKillCount.ToString();
        // 殺した敵キャラの数を表示
        KillEnemyCountText.SetActive(true);
        // クリアしたステージでの敵キャラ破壊数を取得する
        EnemyKillCount += TempEnemyKillCount;
        // 待機
        yield return wait;

        // ガイドテキストの表示
        GuideMessage.SetActive(true);
        // 待機
        yield return wait;
    }
}