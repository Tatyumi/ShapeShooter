using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>ボス</summary>
    public GameObject Boss;
    /// <summary>生成数</summary>
    private int generatCount = 3;
    /// <summary>サブ弾の進行方向</summary>
    private Vector3 subBulletVec = new Vector3(3,0,0); 

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BossBulletSE.name);

        // 生成オブジェクト格納配列
        GameObject[] gameObject = new GameObject[generatCount];

        // 生成数だけオブジェクトを生成
        for(int i = 0; i < generatCount; i++)
        {
            // ゲームオブジェクトを格納
            gameObject[i] = Instantiate(BulletPrefab) as GameObject;

            // ゲームオブジェクトをPauseManagerの子にする
            gameObject[i].transform.SetParent(PauseManager.transform, false);

            // 中ボスの座標に配置する
            gameObject[i].transform.position = Boss.transform.position;
        }

        // プレイヤーの方向を向く
        gameObject[0].transform.LookAt(Player.transform.position);

        var subBulletLeft = Player.transform.position + subBulletVec;
        gameObject[1].transform.LookAt(subBulletLeft);

        var subBulletRight = Player.transform.position - subBulletVec;
        gameObject[2].transform.LookAt(subBulletRight);
    }
}
