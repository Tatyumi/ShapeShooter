using UnityEngine;

public sealed class GuideLightController : MonoBehaviour
{
    /// <summary>ステージ下部</summary>
    public GameObject StageBottom;
    /// <summary>始点座標</summary>
    private Vector3 startPos;
    /// <summary>ガイドライト終点Z座標</summary>
    private const float endPosZ = -20.0f;
    /// <summary>移動速度</summary>
    private const float moveSpeed = -1.2f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトを手前に移動
        transform.Translate(0, 0, moveSpeed);

        // 終点Z座標に達した場合
        if (transform.localPosition.z < endPosZ)
        {
            // 始点に配置
            transform.localPosition = startPos;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 始点のZ座標を取得
        var startPosZ = StageBottom.transform.position.z + 20;

        //// 始点を取得
        startPos = new Vector3(transform.localPosition.x, transform.localPosition.y, startPosZ);

        // 始点に配置
        transform.localPosition = startPos;
    }
}
