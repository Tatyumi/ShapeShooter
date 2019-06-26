using UnityEngine;

/// <summary>
/// Rigidbodyの速度を保存しておくクラス
/// </summary>
public class RigidbodyVelocity
{
    /// <summary> 速度</summary>
    public Vector3 velocity;
    /// <summary>角運動速度</summary>
    public Vector3 angularVeloccity;

    public RigidbodyVelocity(Rigidbody rigidbody)
    {
        velocity = rigidbody.velocity;
        angularVeloccity = rigidbody.angularVelocity;
    }
}