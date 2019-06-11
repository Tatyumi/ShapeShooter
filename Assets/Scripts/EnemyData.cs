using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]

public class EnemyData : ScriptableObject
{
    /// <summary>体力</summary>
    public int Hp;
    /// <summary>スコア</summary>
    public int Score;
    /// <summary>移動速度</summary>
    public float MoveSpeed;
}