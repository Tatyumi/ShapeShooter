using UnityEngine;

public class ThirdBossFormPlayerBulletGenerator : BulletGenerator
{

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.ThirdBossBulletSE.name);

        // 生成するプレファブをゲームオブジェクトに変換
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // プレイヤーの座標から指定の距離をとった座標にゲームオブジェクトを配置
        gameObject.transform.position = Player.transform.position + offset;
    }
}