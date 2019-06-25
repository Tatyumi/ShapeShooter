using UnityEngine;

public sealed class TitleStageController : MonoBehaviour
{
    /// <summary>回転速度</summary>
    private float rotateSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
