using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject laserButtonUp, laserButtonDown, laser;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LoveBall") || col.gameObject.CompareTag("OppositBall"))
        {
            laser.SetActive(false);
            laserButtonUp.GetComponent<SpriteRenderer>().sprite = laserButtonDown.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
