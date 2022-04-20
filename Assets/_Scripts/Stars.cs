using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private GeneralUIManager generalUIManager;
    private int totalStars; // Ana ekranda görünecek olan yıldız sayısı
    private void Start()
    {
        generalUIManager = GeneralUIManager.Instance;
        totalStars += generalUIManager.stars;
    }

    private void Update()
    {
    }

    
}
