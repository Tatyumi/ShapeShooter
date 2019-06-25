using UnityEngine.SceneManagement;
using Common;

public class WhiteLightImageController : FadeInUIController
{
    /// <summary>シーン遷移時の演出</summary>
    protected override void SceneMoveAction()
    {
        // 音の停止
        audioManager.StopSound();

        // 現在のシーンが隠しステージか判別
        if (SceneManager.GetActiveScene().name == SceneName.HIDDEN_STAGE_SCENE)
        {
            // 隠しステージの場合

            // ラスボスシーンに遷移
            SceneManager.LoadScene(SceneName.LAST_BOSS_SCENE);
        }
        else
        {
            // それ以外の場合

            // ボスシーンに遷移
            SceneManager.LoadScene(SceneName.BOSS_SCENE);
        }
    }
}