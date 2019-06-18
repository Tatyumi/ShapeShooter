using UnityEngine;

public class FirstBossBulletController : EnemyBulletController
{
    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="collision">衝突したオブジェクトのコリジョン</param>
    protected override void OnCollisionEnter(Collision collision)
    {
        // 破棄されない
    }
}
