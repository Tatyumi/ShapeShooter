using System.Collections;
using UnityEngine;

public class SecondStageDirector : StageDirector
{
    /// <summary>アドバイステキスト</summary>
    public GameObject AdviceText;
    /// <summary>プレイしたかチェックフラグ</summary>
    private static bool isSecondStagePlay = true;


    private void Start()
    {
        // 初回プレイか判別
        if (isSecondStagePlay)
        {
            // 初回プレイの場合

            // アドバイス表示コルーチンを起動
            var corutine = DisplayAdvice();
            StartCoroutine(corutine);
        }
        else
        {
            // 初回プレイ出ない場合

            // 非表示
            AdviceText.SetActive(false);
        }
    }

    /// <summary>
    /// アドバイス表示コルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator DisplayAdvice()
    {
        // 待機時間
        var wait = new WaitForSeconds(3);

        // 表示
        AdviceText.SetActive(true);

        // 待機
        yield return wait;

        // 非表示
        AdviceText.SetActive(false);

        // フラグ更新
        isSecondStagePlay = false;
    }
}