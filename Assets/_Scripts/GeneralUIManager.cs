using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GeneralUIManager : MonoBehaviour
{
    public static GeneralUIManager Instance;
    private GameManager gameManager;
    [SerializeField] private Text starText;
    private Line line;
    [SerializeField] private Image inkBar, giftBar;
    [SerializeField] private GameObject settingsButton, backButton,
        bgCanvas, bgInkBar, linesDrawer, winPanel;
    [HideInInspector] public float ink = 100, giftPercent = 0, zeroFloat = 0;
    [HideInInspector] public int stars, levelCount = 0;
    public GameObject wheelPanel, giftPanel, losePanel;
    public GameObject starOne, starTwo, starThree;
    public bool settingsBool;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        line = Line.Instance;
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        UpdateInkBar();
        UpdateStarsCount();
        ShowingStars();
    }

    public void UpdateStar()
    {
        starText.text = stars.ToString();
    }
    public void UpdateGiftBar()
    {
        DOTween.To(() => zeroFloat, (giftPercent) => zeroFloat = giftPercent, giftPercent, 2f);
        giftBar.fillAmount = zeroFloat / 100;
        PlayerPrefs.SetFloat("totalGiftPercent", giftPercent);
        if (giftPercent > 100)
            giftPercent = 20;
    }
    public void UpdateInkBar()
    {
        inkBar.fillAmount = ink / 100;
        if (ink >= 100)
            ink = 100;
        else if (ink <= 0)
            ink = 0;
    }
    
    public void UpdateStarsCount()
    {
        if (ink >= 75 && ink <= 100)
            stars = 3;
        else if (ink >= 40 && ink < 75)
            stars = 2;
        else
            stars = 1;
    }
    public void OnClickNextLevelButton(int levelID)
    {
        gameManager.line.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        if (giftPercent >= 100)
        {
            giftPanel.SetActive(false);
            wheelPanel.SetActive(true);
        }
        else
            SceneManager.LoadScene(levelID);
    }

    public void OnClickWheelButton(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
    public void WinGame()
    { 
        winPanel.SetActive(true);
    }
    
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ActiveGiftPanel()
    {
        winPanel.SetActive(false);
        giftPanel.SetActive(true);
    }
    private void ShowingStars()
    {
        if (stars == 1)
        {
            starOne.SetActive(true);
            starTwo.SetActive(false);
            starThree.SetActive(false);
        }
            
        else if(stars == 2)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(false);
        }
        else if(stars == 3)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(true);
        }
    }
}
