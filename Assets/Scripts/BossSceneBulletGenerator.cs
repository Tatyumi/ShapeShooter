using UnityEngine;

public sealed class BossSceneBulletGenerator : BulletGenerator
{
    /// <summary>ボス</summary>
    public GameObject Boss;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // オーディオマネージャーの取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// ゲームオブジェクト生成処理
    /// </summary>
    protected override void Generat()
    {
        // SEの再生
        audioManager.PlaySE(audioManager.BulletSE.name);

        // 生成するプレファブをゲームオブジェクトに変換
        GameObject gameObject = Instantiate(BulletPrefab) as GameObject;

        // ゲームオブジェクトをPauseManagerの子にする
        gameObject.transform.SetParent(PauseManager.transform, false);

        // プレイヤーの座標から指定の距離をとった座標にゲームオブジェクトを配置
        gameObject.transform.position = Vector3.Lerp(Player.transform.position, Boss.transform.position, 0.1f);

        // ゲームオブジェクトの向きをボス方向に指定する
        gameObject.transform.LookAt(Boss.transform.position);
    }
}
