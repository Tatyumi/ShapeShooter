using UnityEngine.SceneManagement;
using Common;

public class GameOverPanelController : FadeInUIController
{
    /// <summary>シーン遷移時の演出</summary>
    protected override void SceneMoveAction()
    {
        // 音の停止
        audioManager.StopSound();

        // タイトルシーンに遷移
        SceneManager.LoadScene(SceneName.TITLE_SCENE);
    }
}