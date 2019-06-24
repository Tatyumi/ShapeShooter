using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create BulletGeneratorData")]

public class BulletGeneratorData : ScriptableObject
{
    /// <summary>生成間隔</summary>
    public float Span;
}