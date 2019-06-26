using UnityEngine;

public class BossSceneBulletGenerator : BulletGenerator
{
    /// <summary>ボス</summary>
    public GameObject Boss;
    /// <summary>対象の座標</summary>
    protected Vector3 targetPos;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // ボスの座標を取得
        targetPos = Boss.transform.position;

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
        gameObject.transform.position = Vector3.Lerp(Player.transform.position, targetPos, 0.1f);

        // ゲームオブジェクトの向きをボス方向に指定する
        gameObject.transform.LookAt(targetPos);
    }
}