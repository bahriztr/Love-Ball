using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GeneralUIManager generalUIManager;

    private void Start()
    {
        generalUIManager = GeneralUIManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("OppositBall"))
        {
            col.gameObject.SetActive(false);
            generalUIManager.losePanel.SetActive(true);           
        }
    }

}  
