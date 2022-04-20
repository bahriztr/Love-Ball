using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GeneralUIManager generalUIManager;
    [HideInInspector] public GameObject loveBallOne, loveBallTwo;
    public GameObject line;
    public bool canScale, isFinishedScale, isGiftPanel, isRbKinematic;
    private void Awake()
    {
        Instance = this;
        loveBallOne = GameObject.FindGameObjectWithTag("LoveBall");
        loveBallTwo = GameObject.FindGameObjectWithTag("OppositBall");
    }

    private void Start()
    {
        line.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        SetBalls();
        if (PlayerPrefs.HasKey("totalGiftPercent"))
        {
            generalUIManager.giftPercent = PlayerPrefs.GetFloat("totalGiftPercent");
        }

    }

    private void Update()
    {
        ScaleLoveBall();
        if (isRbKinematic)
            line.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    public void SetBalls()
    {
        generalUIManager = GeneralUIManager.Instance;
    }
    
    private void ScaleLoveBall()
    {
        if (canScale)
        {
            loveBallTwo.GetComponent<CircleCollider2D>().isTrigger = true;
            loveBallOne.GetComponent<Renderer>().sortingOrder = 0;
            loveBallTwo.transform.DOMove(new Vector2(0, 0), 1f).OnComplete(() =>
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(loveBallTwo.transform.DORotate(new Vector3(0, 0, 0), 0.5f))
                    .Append(loveBallTwo.transform.DOScale(new Vector3(2, 2, 0), 2f))
                    .OnComplete(() =>
                    {
                        generalUIManager.UpdateStar();
                        if (isGiftPanel)
                        {
                            generalUIManager.ActiveGiftPanel();
                        }
                    });
                    StartCoroutine(Delay());
                sequence.Play();
            });
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        generalUIManager.UpdateGiftBar();
    }

    
}
