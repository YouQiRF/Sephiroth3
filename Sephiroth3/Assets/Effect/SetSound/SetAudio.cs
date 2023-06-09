﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetAudio : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("設定音樂")]
    [SerializeField] public List<AudioClip> Setaudio = new List<AudioClip>();
    [Header("呼叫音效編號")]
    [SerializeField] public static int audioNum = 0;
    [Header("設定音效物件")]
    [SerializeField] public AudioSource BGM_Audio;
    [Header("是否關閉音樂音效")]
    [SerializeField] public bool is_audio_play = false;

    public static bool play_BGM = false;
    void Start()
    {
        SetAudioVal.Sound_Val = 0.2f;
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        BGM_Audio.clip = Setaudio[audioNum];
        BGM_Audio.volume = SetAudioVal.Sound_Val;
        //Debug.Log(BGM_Audio.volume);
        is_play();
        play_audio();
    }

    void is_play()
    {
        if (is_audio_play)
        {
            BGM_Audio.mute = true;
        }
        else { BGM_Audio.mute = false; }
    }
    void play_audio()
    {
        if (play_BGM)
        {
            BGM_Audio.Play();
            play_BGM = false;
        }
    }
}
