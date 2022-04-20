using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveBall : MonoBehaviour
{
    private GeneralUIManager generalUIManager;
    private GameManager gameManager;
    public Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        generalUIManager = GeneralUIManager.Instance;
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            gameManager.loveBallOne.GetComponent<Rigidbody2D>().isKinematic = false;
            gameManager.loveBallOne.GetComponent<CircleCollider2D>().isTrigger = false;

            gameManager.loveBallTwo.GetComponent<Rigidbody2D>().isKinematic = false;
            gameManager.loveBallTwo.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LoveBall") || col.gameObject.CompareTag("OppositBall"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            gameManager.line.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; // her yeni levelde freeze aç
            gameManager.loveBallTwo.GetComponent<Renderer>().sortingOrder = 2;
            
            generalUIManager.WinGame();
            
            generalUIManager.giftPercent += 10;

            gameManager.canScale = true;
            gameManager.isRbKinematic = true;
            gameManager.isGiftPanel = true;
            //gameManager.loveBallTwo.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
