using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUIController : MonoBehaviour
{
    /// <summary>フェードスピード</summary>
    private float fadeSpeed = 0.01f;
    /// <summary>目標アルファ値</summary>
    protected float targetAlpha = 0.0f;
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
        // ゲームオブジェクトパネルがアクティブになった場合
        if (gameObject.activeSelf)
        {
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

        // ゲームオーバーパネルの色(RGB)の値を取得
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
