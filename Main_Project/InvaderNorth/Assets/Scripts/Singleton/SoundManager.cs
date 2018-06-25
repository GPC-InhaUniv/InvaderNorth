﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    PlayMain,
    PlayStage1,
    EnemyDie,
    EnmeyShot,
    EnemyDamaged,
    BossDie,
    PlayerDie,
    PlayerShot,
    ButtonClick,
    ButtonStart,
    ButtonUpgrade,
    PlayLoading,
    PlayTutorial,
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource myAudio;
    private AudioClip[] SoundConst;

    private void Awake()
    {
        if (SoundManager.instance == null)
            SoundManager.instance = this;
        else if (SoundManager.instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {

        myAudio = GetComponent<AudioSource>();

        SoundConst = new AudioClip[13];

        SoundConst[0] = Resources.Load<AudioClip>("Audio/Main");
        SoundConst[1] = Resources.Load<AudioClip>("Audio/Stage1");
        SoundConst[2] = Resources.Load<AudioClip>("Audio/BattleDieEnemy");
        SoundConst[3] = Resources.Load<AudioClip>("Audio/BattleEnemyShot");
        SoundConst[4] = Resources.Load<AudioClip>("Audio/BattleEnemyDamaged");
        SoundConst[5] = Resources.Load<AudioClip>("Audio/BattleBossDie");
        SoundConst[6] = Resources.Load<AudioClip>("Audio/BattlePlayerDie");
        SoundConst[7] = Resources.Load<AudioClip>("Audio/BattlePlayerShot");
        SoundConst[8] = Resources.Load<AudioClip>("Audio/ButtonClick");
        SoundConst[9] = Resources.Load<AudioClip>("Audio/ButtonStart");
        SoundConst[10] = Resources.Load<AudioClip>("Audio/ButtonUpgrade");
        SoundConst[11] = Resources.Load<AudioClip>("Audio/Loading");
        SoundConst[12] = Resources.Load<AudioClip>("Audio/Tutorial");

        MainSound();

    }

    public void MainSound()
    {
        myAudio.loop = true;
        SoundManager.instance.PlaySoundType(SoundType.PlayMain);
        DontDestroyOnLoad(transform.gameObject);
    }

    public void PlaySoundType(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.PlayMain:
                myAudio.PlayOneShot(SoundConst[0], 0.05f);
                break;

            case SoundType.PlayStage1:
                myAudio.PlayOneShot(SoundConst[1], 0.05f);
                break;

            case SoundType.EnemyDie:
                myAudio.PlayOneShot(SoundConst[2], 0.05f);
                break;

            case SoundType.EnmeyShot:
                myAudio.PlayOneShot(SoundConst[3], 0.05f);
                break;

            case SoundType.EnemyDamaged:
                myAudio.PlayOneShot(SoundConst[4], 0.05f);
                break;

            case SoundType.BossDie:
                myAudio.PlayOneShot(SoundConst[5], 0.05f);
                break;

            case SoundType.PlayerDie:
                myAudio.PlayOneShot(SoundConst[6], 0.05f);
                break;

            case SoundType.PlayerShot:
                myAudio.PlayOneShot(SoundConst[7], 0.05f);
                break;

            case SoundType.ButtonClick:
                myAudio.PlayOneShot(SoundConst[8], 0.05f);
                break;

            case SoundType.ButtonStart:
                myAudio.PlayOneShot(SoundConst[9], 0.05f);
                break;

            case SoundType.ButtonUpgrade:
                myAudio.PlayOneShot(SoundConst[10], 0.05f);
                break;

            case SoundType.PlayLoading:
                myAudio.PlayOneShot(SoundConst[11], 0.05f);
                break;

            case SoundType.PlayTutorial:
                myAudio.PlayOneShot(SoundConst[12], 0.05f);
                break;
        }
    }
}