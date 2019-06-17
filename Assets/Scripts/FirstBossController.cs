﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : EnemyController
{
    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(moveSpeed, moveSpeed, 0);
    }


    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public override void ApplyDamage()
    {
        // 体力を1減らす 
        hp -= 1;

        // 体力が0以下の場合
        if (hp <= 0)
        {
            // 破壊SE再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // オブジェクトを無効にする
            enabled = false;
            gameObject.SetActive(false);
        }
        else
        {
            // 体力が残っている場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }
    }
}
