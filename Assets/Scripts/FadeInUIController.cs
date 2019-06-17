using UnityEngine;
using UnityEngine.UI;

public abstract class FadeInUIController : MonoBehaviour
{
    /// <summary>フェードスピード</summary>
    protected float fadeSpeed = 0.002f;
    /// <summary>オーディオマネージャー</summary>
    protected AudioManager audioManager;
    /// <summary>目標アルファ値</summary>
    protected float targetAlpha = 0.8f;
    /// <summary>アクションパネル</summary>
    private Image ActionPanel;
    /// <summary>色(RGB)</summary>
    private float red, green, blue;
    /// <summary>アルファ値</summary>
    private float alpha = 0.0f;

    // Start is called before the first frame update
    protected void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    protected void Update()
    {
        // ゲームオブジェクトパネルがアクティブになった場合
        if (gameObject.activeSelf)
        {
            // アルファ値を加算しフェードインする
            ActionPanel.color = new Color(red, green, blue, alpha);
            alpha += fadeSpeed;

            // 一定のアルファ値に達した場合
            if (ActionPanel.color.a >= targetAlpha)
            {
                // シーン遷移時の演出を起こす
                SceneMoveAction();
            }
        }
    }

    // 初期化処理
    private void Initialize()
    {
        // imageコンポーネントの取得
        ActionPanel = gameObject.GetComponent<Image>();

        // ゲームオーバーパネルの色(RGB)の値を取得
        red = ActionPanel.color.r;
        green = ActionPanel.color.g;
        blue = ActionPanel.color.b;

        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // ゲームオブジェクトを非表示
        gameObject.SetActive(false);
    }

    /// <summary>シーン遷移演出</summary>
    protected abstract void SceneMoveAction();
}