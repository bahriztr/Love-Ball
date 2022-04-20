using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("LoveBall") || col.CompareTag("OppositBall")) 
            GeneralUIManager.FindObjectOfType<GeneralUIManager>().losePanel.SetActive(true);
    }
}
