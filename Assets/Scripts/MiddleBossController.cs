using UnityEngine;

public class MiddleBossController : EnemyController
{
    /// <summary>発光画像</summary>
    public GameObject WhiteLightImage;
    /// <summary>ジェネレーター</summary>
    public GameObject MiddleBossBulletGenerator;
    /// <summary>戦闘フラグ</summary>
    public bool isBattle;

    /// <summary>
    /// ダメージ適応処理
    /// </summary>
    public override void ApplyDamage(int damage)
    {
        // ダメージ適応
        hp -= damage;

        // hpチェック
        if (hp <= 0)
        {
            // 0以下の場合

            // 破壊SEの再生
            audioManager.PlaySE(audioManager.DestroySE.name);

            // BGMをフェードアウトする
            audioManager.FadeOutBGM();

            // スコア加算
            ScoreController.AddScore(EnemyData.Score);

            // 撃破数を加算
            ResultPanelController.TempEnemyKillCount++;

            // nullチェック
            if (MiddleBossBulletGenerator != null)
            {
                // nullでない場合

                // ジェネレータを無効にする
                MiddleBossBulletGenerator.GetComponent<EnemyBulletGenerator>().enabled = false;
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
        }
        else
        {
            // 1以上の場合

            // ダメージSEを再生
            audioManager.PlaySE(audioManager.DamageSE.name);
        }
    }
}
