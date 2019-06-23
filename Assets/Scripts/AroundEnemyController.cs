using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundEnemyController : EnemyController
{
    /// <summary>対象オブジェクト</summary>
    private Vector3 targetObject;

    private void Start()
    {
        // 初期化
        base.Initialize();

        // prefabであるため、Find関数を用いて取得している。あまり好きなやり方ではない
        // ステージオブジェクトの座標を取得
        targetObject =  GameObject.Find("Stage").transform.position;
    }

    /// <summary>
    /// 左右に揺れながら移動する
    /// </summary>
    protected override void Move()
    {
        // 移動
        transform.Translate(0, 0, moveSpeed);

        // 対象オブジェクトの座標を中心に右に回転
        transform.RotateAround(targetObject, Vector3.forward, moveSpeed *5);
    }
}
