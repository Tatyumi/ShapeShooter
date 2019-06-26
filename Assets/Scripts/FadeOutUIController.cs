using UnityEngine;
using UnityEngine.UI;

public sealed class FadeOutUIController : MonoBehaviour
{
    /// <summary>フェードスピード</summary>
    private float fadeSpeed = 0.01f;
    /// <summary>目標アルファ値</summary>
    private float targetAlpha = 0.0f;
    /// <summary>アクションパネル</summary>
    private Image FadeOutImage;
    /// <summary>色(RGB)</summary>
    private float red, green, blue;
    /// <summary>アルファ値</summary>
    private float alpha = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        // ゲームオブジェクトの活性状態チェック
        if (gameObject.activeSelf)
        {
            // 活性状態の場合

            // アルファ値を加算しフェードインする
            FadeOutImage.color = new Color(red, green, blue, alpha);
            alpha -= fadeSpeed;

            // 一定のアルファ値を下回った場合
            if (FadeOutImage.color.a <= targetAlpha)
            {
                // フェードアウト時の演出
                FadeOutedAction();
            }
        }
    }

    // 初期化処理
    private void Initialize()
    {
        // imageコンポーネントの取得
        FadeOutImage = gameObject.GetComponent<Image>();

        // imageの色(RGB)の値を取得
        red = FadeOutImage.color.r;
        green = FadeOutImage.color.g;
        blue = FadeOutImage.color.b;

        // ゲームオブジェクトを表示
        gameObject.SetActive(true);
    }

    /// <summary>
    /// フェードアウト時の動作
    /// </summary>
    private void FadeOutedAction()
    {
        // ゲームオブジェクトを表示
        gameObject.SetActive(false);
    }
}
