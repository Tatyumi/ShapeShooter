using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>エネミーデータ</summary>
    public EnemyData EnemyData;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>体力</summary>
    protected int hp;
    /// <summary> 移動速度</summary>
    protected float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    void Update()
    {
        // 移動
        Move();

        // z座標チェック
        CheckPosZ(transform.position.z);
    }


    /// <summary>
    /// 初期化
    /// </summary>
    protected void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 体力の取得
        hp = EnemyData.Hp;

        // 移動速度の取得
        moveSpeed = EnemyData.MoveSpeed * -1;
    }

    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public void ApplyDamage()
    {
        // 体力を1減らす 
        hp -= 1;

        // 体力が0以下の場合
        if (hp <= 0)
        {
            // SE再生
            audioManager.PlaySE(audioManager.DamageSE.name);

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // 破壊処理
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 移動する
    /// </summary>
    protected void Move()
    {
        // 移動
        transform.Translate(0, 0, moveSpeed);
    }
}
