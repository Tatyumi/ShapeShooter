using UnityEngine;

// シングルトンの実装
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            // 存在チェック
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }

            //シーンが遷移しても破棄されない
            DontDestroyOnLoad(instance);

            return instance;
        }
    }
}