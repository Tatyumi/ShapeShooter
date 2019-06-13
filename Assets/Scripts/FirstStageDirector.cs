using Common;
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
        Phase.IsMiddleBoss = false;
    }
}
