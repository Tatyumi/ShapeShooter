using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndRollController : MonoBehaviour
{
    /// <summary>テキストのスクロールスピード</summary>
    private float textScrollSpeed = 70.0f;
    /// <summary>制限座標</summary>
    private float limitPosition = 2700.0f;

    void Start()
    {
        // フラグを更新する
        LastBossController.isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        // エンドロールが終了したか判別
        if (!LastBossController.isEnd)
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
                LastBossController.isEnd = true;
            }
        }
    }
}

