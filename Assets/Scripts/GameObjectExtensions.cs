using System.Linq;
using UnityEngine;

public static class GameObjectExtensions
{
    // 自身を含まない子要素取得関数
    public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self) where T : Component
    {
        return self.GetComponentsInChildren<T>().Where(c => self != c.gameObject).ToArray();
    }
}