using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WheelRotate : MonoBehaviour
{
    public Transform wheelTransform;

    private float genSpeed;
    private float subSpeed;
    private bool isStopped, isSpinning;

    public Button spinButton;
    public GameObject nextLevelPanel;
    private void Start()
    {
        //gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        spinButton.GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
        //spinButton.transform.DOScale(new Vector3(.5f,.5f,0), .5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    void Update()
    {
        if(isSpinning)
        {
            wheelTransform.Rotate(0, 0, genSpeed, Space.World);
            genSpeed -= subSpeed;
        }
        if(genSpeed <= 0 && isSpinning)
        {
            genSpeed = 0;
            isSpinning = false;
            isStopped = true;

            Invoke("OpenPanel",1.5f);

        }
    }


    public void Spinner()
    {
        genSpeed = Random.Range(6.000f, 8.000f);
        subSpeed = Random.Range(0.003f, 0.009f);
        isSpinning = true;
        //gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        spinButton.GetComponent<Button>().enabled = false;

        //Invoke("OpenPanel",genSpeed);
    }
    public void OpenPanel()
    {
        nextLevelPanel.SetActive(true);
        nextLevelPanel.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, .4f); 
    }
}
