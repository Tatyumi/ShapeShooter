using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create BulletData")]


public class BulletData : ScriptableObject
{
    /// <summary>弾速</summary>
    public float Speed;
    /// <summary>生存時間</summary>
    public float LifeTime;
}
