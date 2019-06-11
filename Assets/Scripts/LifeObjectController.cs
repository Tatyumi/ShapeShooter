using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObjectController : MonoBehaviour
{
    /// <summary>回転速度</summary>
    private float rotationSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // 残機オブジェクトを回転
        transform.Rotate(0, rotationSpeed, 0);
    }
}
