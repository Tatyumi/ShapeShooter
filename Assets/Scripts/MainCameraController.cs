using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class MainCameraController : MonoBehaviour
{
    /// <summary>プレイヤー</summary>
    public GameObject Player;
    /// <summary>ステージ</summary>
    public GameObject Stage;
    /// <summary>プレイヤーとカメラの距離</summary>
    private Vector3 offset;
    /// <summary>移動速度</summary>
    private float moveSpeed;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // →を押した場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ステージ座標を中心に右に回転
            transform.RotateAround(Stage.transform.position, Vector3.forward, moveSpeed);
        }

        // ←を押した場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ステージ座標を中心に左に回転
            transform.RotateAround(Stage.transform.position, Vector3.forward, moveSpeed * -1);
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // プレイヤーの移動速度を取得
        moveSpeed = Player.GetComponent<PlayerController>().MoveSpeed;
    }

}
