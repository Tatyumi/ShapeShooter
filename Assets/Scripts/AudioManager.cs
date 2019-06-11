using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>ファーストステージのBGM</summary>
    public AudioClip FirstStageBGM;
    /// <summary>弾発射SE</summary>
    public AudioClip BulletSE;
    /// <summary>ダメージSE</summary>
    public AudioClip DamageSE;
    /// <summary>プレイヤー破壊SE</summary>
    public AudioClip PlayerDestroySE;
    /// <summary>オーディオソース</summary>
    AudioSource audioSource;
    /// <summary>全SE保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> SEDic;
    /// <summary>全BGM保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> BGMDic;

    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        audioSource = gameObject.GetComponent<AudioSource>();

        // SEを格納
        SEDic = new Dictionary<string, AudioClip> {
            { BulletSE.name, BulletSE},
            { DamageSE.name, DamageSE},
            { PlayerDestroySE.name, PlayerDestroySE},
        };

        // BGMを格納
        BGMDic = new Dictionary<string, AudioClip>
        {
            {FirstStageBGM.name,FirstStageBGM }
        };
    }

    /// <summary>
    /// BGMの再生
    /// </summary>
    /// <param name="BGMName">BGMの名前</param>
    public void PlayBGM(string BGMName)
    {
        // 名前のチェック
        if (!BGMDic.ContainsKey(BGMName))
        {
            Debug.Log(BGMName + "という名前のBGMがありません");
            return;
        }

        // BGMの再生
        audioSource.PlayOneShot(BGMDic[BGMName]);
    }

    /// <summary>
    /// SEの再生
    /// </summary>
    /// <param name="SEName">SEの名前</param>
    public void PlaySE(string SEName)
    {
        // 名前のチェック
        if (!SEDic.ContainsKey(SEName))
        {
            Debug.Log(SEName + "という名前のSEがありません");
            return;
        }

        // SEの再生
        audioSource.PlayOneShot(SEDic[SEName]);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopSound()
    {
        audioSource.Stop();
    }

}
