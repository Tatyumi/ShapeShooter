using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    /// <summary>残機数テキストコントローラーオブジェクト</summary>
    public GameObject LifeCountTextController;
    /// <summary>スコア</summary>
    public static int score = 0;
    /// <summary>ワンアップスコア</summary>
    public static int OneUpScore;
    /// <summary>ワンアップスコア基準値</summary>
    public static int OneUpScoreBaseValue = 10000;
    /// <summary>スコアテキスト</summary>
    private static Text scoreText;
    /// <summary>残機数テキストコントローラー</summary>
    private static LifeCountTextController life;

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

        // コンポーネントの取得
        life = LifeCountTextController.GetComponent<LifeCountTextController>();
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

        // スコアがワンアップスコアに達したか判別
        if(score >= OneUpScore)
        {
            // 達した場合

            // 1up処理
            life.OneUpLife();

            // ワンアップするスコアを更新する
            OneUpScore += OneUpScoreBaseValue;
        }
    }
}
