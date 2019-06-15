using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
    /// <summary>ポーズフラグ</summary>
	public static bool isPause;
    /// <summary>無視するGameObject</summary>
    public GameObject[] ignoreGameObjects;
    /// <summary>ポーズ状態が変更された瞬間を調べるため、前回のポーズ状況を記録しておく</summary>
    bool prevPausing;
    /// <summary>Rigidbodyのポーズ前の速度の配列</summary>
    RigidbodyVelocity[] rigidbodyVelocities;
    /// <summary>ポーズ中のRigidbodyの配列</summary>
    Rigidbody[] pausingRigidbodies;
    /// <summary>ポーズ中のMonoBehaviourの配列</summary>
    MonoBehaviour[] pausingMonoBehaviours;
    /// <summary>ポーズパネル</summary>
    public GameObject PausePanel;
    /// <summary>エネミージェネレーター</summary>
    public EnemyGenerator enemyGenerator;


    private void Start()
    {
        // 初期化
        Initialize();
    }

    void Update()
    {
        // プレイヤーが生きている状態で「P」キーを押下した場合
        if (Input.GetKeyUp(KeyCode.P) && !PlayerController.IsDie)
        {
            // ポーズ状態に変更する
            isPause = !isPause;
            PausePanel.SetActive(isPause);
        }

        // ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
        if (prevPausing != isPause)
        {
            // enemyGeneratorのnukkチェック
            if (enemyGenerator != null)
            {
                if (isPause)
                {
                    // 中断
                    enemyGenerator.Stop();
                    Pause();
                }
                else
                {
                    // 再開
                    Resume();
                    enemyGenerator.Restart();
                }
            }
            else
            {
                if (isPause)
                {
                    // 中断
                    Pause();
                }
                else
                {
                    // 再開
                    Resume();
                }
            }
            prevPausing = isPause;
        }
    }

    /// <summary>
    /// 中断
    /// </summary>
    void Pause()
    {
        // Rigidbodyの停止
        // 子要素から、スリープ中でなく、IgnoreGameObjectsに含まれていないRigidbodyを抽出
        Predicate<Rigidbody> rigidbodyPredicate =
            obj => !obj.IsSleeping() &&
                   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pausingRigidbodies = Array.FindAll(transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate);
        rigidbodyVelocities = new RigidbodyVelocity[pausingRigidbodies.Length];
        for (int i = 0; i < pausingRigidbodies.Length; i++)
        {
            // 速度、角速度も保存しておく
            rigidbodyVelocities[i] = new RigidbodyVelocity(pausingRigidbodies[i]);
            pausingRigidbodies[i].Sleep();
        }

        // MonoBehaviourの停止
        // 子要素から、有効かつこのインスタンスでないもの、IgnoreGameObjectsに含まれていないMonoBehaviourを抽出
        Predicate<MonoBehaviour> monoBehaviourPredicate =
            obj => obj.enabled &&
                   obj != this &&
                   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
        pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
        foreach (var monoBehaviour in pausingMonoBehaviours)
        {
            monoBehaviour.enabled = false;
        }
    }

    /// <summary>
    /// 再開
    /// </summary>
    void Resume()
    {
        // Rigidbodyの再開
        for (int i = 0; i < pausingRigidbodies.Length; i++)
        {
            pausingRigidbodies[i].WakeUp();
            pausingRigidbodies[i].velocity = rigidbodyVelocities[i].velocity;
            pausingRigidbodies[i].angularVelocity = rigidbodyVelocities[i].angularVeloccity;
        }

        // MonoBehaviourの再開
        foreach (var monoBehaviour in pausingMonoBehaviours)
        {
            monoBehaviour.enabled = true;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // ポーズパネルを非表示
        PausePanel.SetActive(false);

        // enemyGeneratorのnukkチェック
        if (enemyGenerator != null)
        {
            // enemyGeneratorのコンポーネントを取得
            enemyGenerator = enemyGenerator.GetComponent<EnemyGenerator>();
        }
    }
}
