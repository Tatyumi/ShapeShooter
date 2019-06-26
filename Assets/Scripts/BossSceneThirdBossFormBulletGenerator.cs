using UnityEngine;

public class BossSceneThirdBossFormBulletGenerator : BossSceneBulletGenerator
{
    /// <summary>
    /// ゲームオブジェクト生成処理
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
        gameObject.transform.position = Vector3.Lerp(Player.transform.position, targetPos, 0.1f);

        // ゲームオブジェクトの向きをボス方向に指定する
        gameObject.transform.LookAt(targetPos);
    }
}