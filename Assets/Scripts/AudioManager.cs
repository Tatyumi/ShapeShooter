using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>ファーストステージのBGM</summary>
    public AudioClip FirstStageBGM;
    /// <summary>セカンドステージのBGM[</summary>
    public AudioClip SecondStageBGM;
    /// <summary>サードステージのBGM[</summary>
    public AudioClip ThirdStageBGM;
    /// <summary>ボスシーンのBGM</summary>
    public AudioClip BossSceneBGM;
    /// <summary>エンディングBGM</summary>
    public AudioClip EndingBGM;
    /// <summary>隠しステージBGM</summary>
    public AudioClip HiddenStageBGM;
    /// <summary>ラストボスシーンのBGM</summary>
    public AudioClip LastBossSceneBGM;
    /// <summary>弾発射SE</summary>
    public AudioClip BulletSE;
    /// <summary>破壊SE</summary>
    public AudioClip DestroySE;
    /// <summary>ダメージSE</summary>
    public AudioClip DamageSE;
    /// <summary>プレイヤー破壊SE</summary>
    public AudioClip PlayerDestroySE;
    /// <summary>ダメージ無効SE</summary>
    public AudioClip NoDamageSE;
    /// <summary>リザルトSE</summary>
    public AudioClip ResultSE;
    /// <summary>ボスの弾発射SE</summary>
    public AudioClip BossBulletSE;
    /// <summary>テキスト表示SE</summary>
    public AudioClip TextOnSE;
    /// <summary>バリア破壊SE</summary>
    public AudioClip BreakBarrierSE;
    /// <summary>セカンドボスの弾発射SE</summary>
    public AudioClip SecondBossBulletSE;
    /// <summary>サードボスの弾発射SE</summary>
    public AudioClip ThirdBossBulletSE;
    /// <summary>ワンアップSE</summary>
    public AudioClip OneUpSE;
    /// <summary>オーディオソース</summary>
    AudioSource audioSource;
    /// <summary>全SE保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> SEDic;
    /// <summary>全BGM保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> BGMDic;
    /// <summary>初期ボリューム</summary>
    private float defaultVolume = 1.0f;
    /// <summary>フェードスピード</summary>
    private float fadeSpeed = 0.3f;
    /// <summary>フェードアウトフラグ</summary>
    private bool isFadeOut;


    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        // フラグ初期化
        isFadeOut = false;

        // AudioSourceコンポーネントの取得
        audioSource = gameObject.GetComponent<AudioSource>();

        // 音量の初期化
        audioSource.volume = defaultVolume;


        // SEを格納
        SEDic = new Dictionary<string, AudioClip> {
            { BulletSE.name, BulletSE},
            { DestroySE.name, DestroySE},
            { PlayerDestroySE.name, PlayerDestroySE},
            { DamageSE.name, DamageSE},
            { NoDamageSE.name, NoDamageSE},
            { ResultSE.name, ResultSE},
            { BossBulletSE.name, BossBulletSE},
            { TextOnSE.name, TextOnSE},
            { BreakBarrierSE.name, BreakBarrierSE},
            { SecondBossBulletSE.name, SecondBossBulletSE},
            { ThirdBossBulletSE.name, ThirdBossBulletSE},
            { OneUpSE.name, OneUpSE},
        };

        // BGMを格納
        BGMDic = new Dictionary<string, AudioClip>
        {
            {FirstStageBGM.name,FirstStageBGM },
            {SecondStageBGM.name,SecondStageBGM },
            {ThirdStageBGM.name,ThirdStageBGM },
            {BossSceneBGM.name,BossSceneBGM },
            {EndingBGM.name,EndingBGM },
            {HiddenStageBGM.name,HiddenStageBGM },
            {LastBossSceneBGM.name,LastBossSceneBGM }
        };
    }

    private void Update()
    {
        if (isFadeOut)
        {
            // 徐々にボリュームを下げる
            audioSource.volume -= Time.deltaTime * fadeSpeed;

            // ボリュームが0以下か判別
            if(audioSource.volume <= 0)
            {
                // 0以下の場合

                // 音の停止
                audioSource.Stop();

                // ボリュームを初期値に戻す
                audioSource.volume = defaultVolume;

                // フラグ更新
                isFadeOut = false;
            }
        }
    }

    /// <summary>
    /// BGMのフェードアウトを有効にする
    /// </summary>
    public void FadeOutBGM()
    {
        isFadeOut = true;
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
        audioSource.clip = BGMDic[BGMName] as AudioClip;
        audioSource.Play();
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
        // 再生中の音をすべて停止する
        audioSource.Stop();
    }
}
