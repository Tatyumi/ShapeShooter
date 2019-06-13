using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Common;

public sealed class LifeCountTextController : MonoBehaviour
{
    /// <summary>残機数</summary>
    public static int LifeCount = 3;
    /// <summary>残機数テキスト</summary>
    public Text LifeCountText;
    /// <summary>ゲームオーバーパネル</summary>
    public GameObject GameOverPanel;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>初期化</summary>
    private void Initialize()
    {
        // 残機数表示
        LifeCountText.text = LifeCount.ToString();

        // 音楽データ取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// 残機数加算
    /// </summary>
    public void AddLifeCount()
    {
        // TODO 残機アップSEの追加

        // 残機数を1増やす
        LifeCount++;

        //残機数表示
        LifeCountText.text = LifeCount.ToString();
    }


    /// <summary>
    /// 残機数減算
    /// </summary>
    public void ReduceLifeCount()
    {
        // 残機数を1減らす
        LifeCount--;

        //残機数表示
        LifeCountText.text = LifeCount.ToString();

        // 全てのオブジェクトの操作を停止する
        PauseManager.isPause = true;

        // 残機数が0以下の場合
        if (LifeCount <= 0)
        {
            // ゲームオーバー処理
            GameOverPanel.SetActive(true);
        }
        else
        {
            // 残機数が0より大きい場合

            // シーン再読み込み
            StartCoroutine(SceneReload());
        }
    }

    /// <summary>
    /// 現在のシーンの再読み込みする
    /// </summary>
    /// <returns></returns>
    IEnumerator SceneReload()
    {
        // 待機時間
        var wait = new WaitForSeconds(5);

        // 5秒待機
        yield return wait;

        // 音楽の停止
        audioManager.StopSound();

        // TODO 進捗に合わせて再読み込みを行うようにする
        // 現在のシーンを再読み込み
        SceneManager.LoadScene(SceneName.FIRST_STAGE_SCENE);
    }

}
