using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WallGenerator : MonoBehaviour
{
    /// <summary>ウォールプレファブリスト</summary>
    public GameObject[] WallPrefabLists;
    /// <summary>ポーズマネージャー</summary>
    public GameObject PauseManager;
    /// <summary>コルーチン</summary>
    protected IEnumerator corutine;

    // Start is called before the first frame update
    void Start()
    {
        // コルーチンの取得
        corutine = StartGenerat();

        // 処理開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 指定した壁を生成する
    /// </summary>
    /// <param name="index">要素番号</param>
    protected void GeneratWall(int index)
    {
        //生成するプレファブをゲームオブジェクトに変換
        var wallObj = Instantiate(WallPrefabLists[index]) as GameObject;

        //ゲームオブジェクトをPauseManagerの子にする
        wallObj.transform.SetParent(PauseManager.transform, false);

        // ゲームオブジェクトを指定の座標に配置
        wallObj.transform.position = transform.position;
    }

    /// <summary>
    /// コルーチン停止
    /// </summary>
    public void Stop()
    {
        StopCoroutine(corutine);
    }

    /// <summary>
    /// コルーチン再開
    /// </summary>
    public void Restart()
    {
        StartCoroutine(corutine);
    }

    // 生成開始処理
    protected abstract IEnumerator StartGenerat();
}
