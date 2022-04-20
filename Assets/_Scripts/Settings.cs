using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Settings : MonoBehaviour
{
    private GeneralUIManager generalUIManager;
    [SerializeField] private GameObject settingsMenu;
    private void Start()
    {
        generalUIManager = GeneralUIManager.Instance;
    }

    public void OnClickSettingsButton()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        generalUIManager.settingsBool = true;
    }

    public void OnClickCloseButton()
    {
        generalUIManager.settingsBool = false;
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
