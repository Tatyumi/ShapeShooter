using Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMessagePanelController : MonoBehaviour
{
    /// <summary>クリアメッセージ</summary>
    public GameObject ClearMessage;
    /// <summary>サンクメッセージ</summary>
    public GameObject ThankMessage;
    /// <summary>グッドバイメッセージ</summary>
    public GameObject GoodByeMessage;
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
        if (gameObject.activeSelf && !isResult)
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
        ThankMessage.SetActive(false);
        GoodByeMessage.SetActive(false);
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
        // 次のシーンに遷移するまでの待機時間
        var nextScenewait = new WaitForSeconds(7.5f);

        // クリアメッセージの表示
        ClearMessage.SetActive(true);
        // 待機
        yield return wait;

        // サンクメッセージの表示
        ThankMessage.SetActive(true);
        // テキスト表示SE再生
        audioManager.PlaySE(audioManager.TextOnSE.name);
        // 待機
        yield return wait;

        // グッドバイメッセージの表示
        GoodByeMessage.SetActive(true);
        // テキスト表示SE再生
        audioManager.PlaySE(audioManager.TextOnSE.name);

        // 次のシーンに遷移するまでの待機
        yield return nextScenewait;

        // タイトルシーンに遷移する
        SceneManager.LoadScene(SceneName.TITLE_SCENE);
    }
}