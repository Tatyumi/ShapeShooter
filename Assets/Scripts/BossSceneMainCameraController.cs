using UnityEngine;

public sealed class BossSceneMainCameraController : MainCameraController
{
    protected override void Move()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.down, moveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 対象オブジェクトの座標を中心に左に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.up, moveSpeed);
        }
    }
}
