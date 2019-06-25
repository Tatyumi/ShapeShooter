using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossController : EnemyController
{
    /// <summary>初期位置</summary>
    private Vector3 startPos = new Vector3(-1, 60, 20.8f);
    /// <summary>落下速度</summary>
    private float fallSpeed = 0.1f;
    /// <summary>戦闘開始ポジション</summary>
    private float battleStartPos = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // 動く
        Move();

        // 一定座標に達したか判別
        if (transform.position.y <= battleStartPos)
        {
            // 達した場合

        }
        else
        {
            // 達していない場合

            // 下降する
            transform.localPosition = 
                new Vector3(transform.localPosition.x, transform.localPosition.y - fallSpeed, transform.localPosition.z);
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 体力の取得
        hp = EnemyData.Hp;

        // 移動速度の取得
        moveSpeed = EnemyData.MoveSpeed * -1;

        // 初期位置の代入
        transform.localPosition = startPos;
    }


    /// <summary>
    /// 動作
    /// </summary>
    protected override void Move()
    {
        // 回転
        transform.Rotate(0, moveSpeed, moveSpeed);
    }
}
