﻿using UnityEngine;

public class FirstBossBulletController : EnemyBulletController
{
    /// <summary>
    /// 衝突処理
    /// </summary>
    public override void ConflictBullet()
    {
        // ダメージ無効SEの再生
        audioManager.PlaySE(audioManager.NoDamageSE.name);
    }
}
