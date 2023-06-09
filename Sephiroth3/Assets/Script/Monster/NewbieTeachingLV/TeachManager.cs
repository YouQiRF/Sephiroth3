﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.AvatarData;
using Project.PlayerHpData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeachManager : MonoBehaviour
{
    [SerializeField] public bool isOpen;
    [SerializeField] public int nowNumber;
    [SerializeField] private HpData[] hpSetObj;
    [SerializeField] private GameObject[] teacjObj;
    [SerializeField] private GameObject[] Buttons;
    [SerializeField] private GameObject PageNumber;

    [SerializeField] private Image[] TargetImage;
    [SerializeField] private Sprite onsprite;
    [SerializeField] private Sprite offsprite;

    // Start is called before the first frame update
    async void Start()
    {
        StartHPSet();
        await Task.Delay(500); OpenTeach();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScenes");
        }
    }

    private void StartHPSet()
    {
        hpSetObj[0].NowHP = 15;
        hpSetObj[1].NowHP = 18;
        hpSetObj[2].NowHP = 15;
    }

    public void OpenTeach()
    {
        chang_target_image();
        PageNumber.SetActive(true);
        if (!isOpen)
        {
            var GameManager = FindObjectOfType<GamePlayingManager>();
            nowNumber = 0;
            isOpen = true;
            TeachDisplay();
            ButtonDisplay();
            GameManager.StopGame();
        }
    }

    public void PushButton(int addNumber)
    {
        nowNumber += addNumber;
        LoopCheck();
        TeachDisplay();
        ButtonDisplay();
    }

    public void CloseTeach()
    {
        var GameManager = FindObjectOfType<GamePlayingManager>();
        isOpen = false;
        TeachDisplay();
        ButtonDisplay();
        GameManager.StopGame();
        PageNumber.SetActive(false);
    }

    public void TeachDisplay()
    {
        if (!isOpen)
        {
            for (int i = 0; i < teacjObj.Length; i++)
            {
                teacjObj[i].SetActive(false);
                Buttons[i].SetActive(false);
                chang_target_image();
            }
        }
        else
        {

            for (int i = 0; i < teacjObj.Length; i++)
            {
                teacjObj[i].SetActive(false);
                chang_target_image();
            }
            teacjObj[nowNumber].SetActive(true);
        }
    }

    private void LoopCheck()
    {
        if (nowNumber >= teacjObj.Length)
        {
            nowNumber = teacjObj.Length - 1;
        }

        if (nowNumber < 0)
        {
            nowNumber = 0;
        }
    }

    public void ButtonDisplay()
    {
        if (isOpen)
        {
            Buttons[0].SetActive(true);
            if (nowNumber <= 0)
            {
                Buttons[1].SetActive(false);
            }
            else
            {
                Buttons[1].SetActive(true);
            }
            if (nowNumber >= teacjObj.Length - 1)
            {
                Buttons[2].SetActive(false);
            }
            else
            {
                Buttons[2].SetActive(true);
            }
        }
    }
    public void chang_target_image()
    {
        if (nowNumber == 0)
        {
            TargetImage[0].sprite = onsprite;
            TargetImage[1].sprite = offsprite;
            TargetImage[2].sprite = offsprite;
        }

        if (nowNumber == 1)
        {
            TargetImage[0].sprite = offsprite;
            TargetImage[1].sprite = onsprite;
            TargetImage[2].sprite = offsprite;
        }

        if (nowNumber == 2)
        {
            TargetImage[0].sprite = offsprite;
            TargetImage[1].sprite = offsprite;
            TargetImage[2].sprite = onsprite;
        }
    }
}

