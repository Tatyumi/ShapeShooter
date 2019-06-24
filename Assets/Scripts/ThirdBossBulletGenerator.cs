using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BossBulletSE.name);

        // 生成オブジェクト格納配列
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // Generatorの座標に配置する
        gameObject.transform.position = transform.position;

        // プレイヤーの方向を向く
        gameObject.transform.LookAt(Player.transform.position);
    }
}