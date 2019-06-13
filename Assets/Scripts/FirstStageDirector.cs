using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageDirector : MonoBehaviour
{
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Awake()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // BGMの再生
        audioManager.PlayBGM(audioManager.FirstStageBGM.name);

        // フラグ初期化
        PauseManager.isPause = false;

    }
}
