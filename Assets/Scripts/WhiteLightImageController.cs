using UnityEngine.SceneManagement;
using Common;

public class WhiteLightImageController : DirectionUIController
{
    /// <summary>シーン遷移時の演出</summary>
    protected override void SceneMoveAction()
    {
        // 音の停止
        audioManager.StopSound();

        // ボスシーンに遷移
        SceneManager.LoadScene(SceneName.BOSS_SCENE);
    }
}