using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMiddleBossController : EnemyController
{
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>発光画像</summary>
    public GameObject WhiteLightImage;
    /// <summary>ジェネレーター</summary>
    public GameObject MiddleBossBulletGenerator;
    /// <summary>戦闘フラグ</summary>
    public bool isBattle;
    /// <summary>降下停止z座標</summary>
    private float stopPositionY;
    /// <summary>降下速度</summary>
    private float fallSpeed = -0.05f;
    private Transform rotationY;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        // 初期化
        base.Initialize();

        // 初期位置に配置
        transform.localPosition = new Vector3(Stage.transform.position.x, 8.0f, 10.0f);

        // ステージのy座標を取得
        stopPositionY = Stage.transform.localPosition.y;

        // フラグ更新
        isBattle = false;
        enabled = false;

        rotationY = gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {

        // フラグチェック
        if (isBattle)
        {
            // trueの場合

            //var rotation = transform.rotation;
            //rotation.y += moveSpeed;

            //// 回転処理
            //transform.rotation = rotation;
            transform.eulerAngles += new Vector3(0, 0, moveSpeed);
        }
        else
        {
            // falseの場合

            // 座標に達しているか判別
            if (transform.localPosition.y >= stopPositionY)
            {
                //　下方向に移動
                transform.Translate(fallSpeed, 0, 0);
            }
            else
            {
                // バトルフラグ更新
                isBattle = true;
            }
        }
    }

    /// <summary>
    /// ダメージを適用する
    /// </summary>
    public override bool ApplyDamage()
    {
        // hpを1減らす 
        hp -= 1;

        // hpチェック
        if (hp <= 0)
        {
            // hpが0以下の場合

            // 破壊SE再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // nullチェック
            if (MiddleBossBulletGenerator != null)
            {
                // nullでない場合

                // ジェネレータを無効にする
                MiddleBossBulletGenerator.GetComponent<SecondMiddleBossBulletGenerator>().enabled = false;
            }

            // nullチェック
            if (WhiteLightImage != null)
            {
                // nullではない場合

                // 発光画像の表示を行う
                WhiteLightImage.SetActive(true);
            }

            // 破棄する
            Destroy(gameObject);

            return true;
        }
        else
        {
            // hpが1以上の場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
            return false;
        }
    }
}
