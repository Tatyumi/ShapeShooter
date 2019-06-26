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

            // BGMをフェードアウトする
            audioManager.FadeOutBGM();

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

        return hp <= 0;
    }
}
