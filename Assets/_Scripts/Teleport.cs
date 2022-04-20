using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("LoveBall"))
        {
            GameManager.FindObjectOfType<GameManager>().loveBallOne.transform.position = TeleportManager.FindObjectOfType<TeleportManager>().teleportTwo.transform.position;
        }
    }
}
