using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Common;

public class GameOverPanelController : MonoBehaviour
{
    /// <summary>ゲームオーバーパネル</summary>
    private Image gameOverPanel;
    /// <summary>色(RGB)</summary>
    private float red, green, blue;
    /// <summary>アルファ値</summary>
    private float alpha = 0.0f;
    /// <summary>フェードインスピード</summary>
    private float fadeInSpeed = 0.002f;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオブジェクトパネルがアクティブになった場合
        if (gameObject.activeSelf)
        {
            // アルファ値を加算しフェードインする
            gameOverPanel.color = new Color(red, green, blue, alpha);
            alpha += fadeInSpeed;

            // 一定のアルファ値に達した場合
            if(gameOverPanel.color.a >= 0.8f)
            {
                // 音の停止
                audioManager.StopSound();

                // タイトルシーンに遷移
                SceneManager.LoadScene(SceneName.TITLE_SCENE);
            }
        }
    }

    // 初期化処理
    private void Initialize()
    {
        // imageコンポーネントの取得
        gameOverPanel = gameObject.GetComponent<Image>();

        // ゲームオーバーパネルの色(RGB)の値を取得
        red = gameOverPanel.color.r;
        green = gameOverPanel.color.g;
        blue = gameOverPanel.color.b;

        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // ゲームオブジェクトを非表示
        gameObject.SetActive(false);
    }
}
