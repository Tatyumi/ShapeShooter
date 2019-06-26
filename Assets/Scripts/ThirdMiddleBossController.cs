using UnityEngine;

public sealed class ThirdMiddleBossController : MiddleBossController
{
    public Transform[] GeneratSpots;
    /// <summary>回転速度</summary>
    private const float rotateSpeed = -100.0f;
    /// <summary>最小Z座標</summary>
    private const float minPositionZ = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        // 初期化
        base.Initialize();

        // 無効にする
        enabled = false;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected override void Move()
    {
        // 回転処理
        transform.Rotate(rotateSpeed, 0, 0);

        // 移動処理
        //transform.Translate(0,0,moveSpeed);
        transform.position += new Vector3(0, 0, moveSpeed);

        // オブジェクトのz座標が指定のz座標以下になったか
        if(transform.position.z < minPositionZ)
        {
            // 指定のz座標以下の場合

            var spotNumber = Random.Range(0, GeneratSpots.Length);

            // ゲームオブジェクトを指定の座標に配置
            gameObject.transform.SetPositionAndRotation(GeneratSpots[spotNumber].position, GeneratSpots[spotNumber].rotation);
        }
    }
}
