using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public sealed class EndRollController : MonoBehaviour
{
    /// <summary>最後に表示するメッセージ</summary>
    public GameObject LastMessage;
    /// <summary>テキストのスクロールスピード</summary>
    private const float textScrollSpeed = 55.0f;
    /// <summary>制限座標</summary>
    private const float limitPosition = 1235.0f;
    /// <summary>エンドロール終了フラグ</summary>
    private bool isEndRoll = false;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    void Start()
    {
        // 非表示にする
        LastMessage.SetActive(false);

        // オーディオマネージャー取得
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // エンドロールが終了したか判別
        if (isEndRoll)
        {
            // 終了した場合

            // ラストメッセージの表示
            LastMessage.SetActive(true);

            // スペースキーを押したか判別
            if (Input.GetKey(KeyCode.Space))
            {
                // 押した場合

                // 音楽の停止
                audioManager.StopSound();

                // タイトルシーンに遷移する
                SceneManager.LoadScene(SceneName.TITLE_SCENE);
            }
        }
        else
        {
            // 終了していない場合

            // 制限座標を超えていないか判別
            if (transform.localPosition.y <= limitPosition)
            {
                // 超えていない場合

                // y座標に移動する
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            }
            else
            {
                // 超えた場合

                // フラグを更新する
                isEndRoll = true;
            }
        }
    }
}