using UnityEngine;

public sealed class SecondBossBulletGenerator : EnemyBulletGenerator
{
    /// <summary>ボス</summary>
    public GameObject Boss;

    /// <summary>
    /// 生成する
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.SecondBossBulletSE.name);

        // 生成オブジェクト格納配列
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // 中ボスの座標に配置する
        gameObject.transform.position = Boss.transform.position;

        // プレイヤーの方向を向く
        gameObject.transform.LookAt(Player.transform.position);
    }
}