using UnityEngine;

public sealed class BossSceneMainCameraController : MainCameraController
{
    /// <summary>対象物のポジション</summary>
    private Vector3 targetPosition;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        // 初期化
        base.Initialize();

        // 対象のオブジェクトの座標を取得
        targetPosition = TargetObj.transform.position;
    }

    protected override void Move()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(targetPosition, Vector3.down, moveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 対象オブジェクトの座標を中心に左に回転
            transform.RotateAround(targetPosition, Vector3.up, moveSpeed);
        }
    }
}
