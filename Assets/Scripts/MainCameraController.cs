using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>対象オブジェクト</summary>
    public GameObject TargetObj;
    /// <summary>移動速度</summary>
    protected float moveSpeed;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        Move();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {
        // プレイヤーの移動速度を取得
        moveSpeed = Player.GetComponent<PlayerListsController>().MoveSpeed;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    protected virtual void Move()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 対象オブジェクトの座標を中心に右に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.forward, moveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 対象オブジェクトの座標を中心に左に回転
            transform.RotateAround(TargetObj.transform.position, Vector3.forward, moveSpeed * -1);
        }
    }
}
