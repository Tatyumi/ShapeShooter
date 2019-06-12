using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>スコア</summary>
    public static int score = 0;
    /// <summary>スコアテキスト</summary>
    private static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 自身のコンポーネントを取得
        scoreText = gameObject.GetComponent<Text>();

        // 初期値を代入
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="getScore">取得したスコア</param>
    public static void AddScore(int getScore)
    {
        // スコア加算
        score += getScore;

        // テキストに代入
        scoreText.text = score.ToString();
    }

}
