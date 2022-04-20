using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDrawer : MonoBehaviour
{
    private GameManager gameManager;
    private GeneralUIManager generalUIManager;
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    int cantDrawOverLayerIndex;

    [Space ( 30f )]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    private Vector2 lastPos;
    private float delta;
    
    Line currentLine;

    Camera cam;

    [SerializeField] private Rigidbody2D loveBallOne;
    [SerializeField] private Rigidbody2D loveBallTwo;
    void Start ( )
    {
        gameManager = GameManager.Instance;
        generalUIManager = GeneralUIManager.Instance;
        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer ( "CantDrawOver" );
    }

    void Update ( ) {
        if ( Input.GetMouseButtonDown ( 0 ) )
            BeginDraw ( );

        if ( currentLine != null )
            Draw ( );

        if ( Input.GetMouseButtonUp ( 0 ) )
            EndDraw ( );
    }

    void BeginDraw ( ) {
        currentLine = Instantiate ( linePrefab, this.transform ).GetComponent <Line> ( );

        currentLine.UsePhysics ( false );
        currentLine.SetLineColor ( lineColor );
        currentLine.SetPointsMinDistance ( linePointsMinDistance );
        currentLine.SetLineWidth ( lineWidth );

    }

    void Draw ( ) {
        if (!generalUIManager.settingsBool)
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );

            RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer );

            if ( hit )
                EndDraw ( );
            else
                currentLine.AddPoint ( mousePosition );
            if (currentLine.pointsCount >= 2)
            {
                generalUIManager.ink -= 0.2f;
            }
        }

        gameManager.loveBallOne.GetComponent<CircleCollider2D>().isTrigger = true;
        gameManager.loveBallOne.GetComponent<Rigidbody2D>().isKinematic = true;

        gameManager.loveBallTwo.GetComponent<CircleCollider2D>().isTrigger = true;
        gameManager.loveBallTwo.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    void EndDraw ( ) {
        if ( currentLine != null ) {
            if ( currentLine.pointsCount < 2 ) {
                Destroy ( currentLine.gameObject );
            } else {
                currentLine.gameObject.layer = cantDrawOverLayerIndex;

                currentLine.UsePhysics ( true );

                currentLine = null;

                gameManager.loveBallOne.GetComponent<Rigidbody2D>().gravityScale = 1f;
                gameManager.loveBallOne.GetComponent<CircleCollider2D>().isTrigger = false;
                gameManager.loveBallOne.GetComponent<Rigidbody2D>().isKinematic = false;

                gameManager.loveBallTwo.GetComponent<Rigidbody2D>().gravityScale = 1f;
                gameManager.loveBallTwo.GetComponent<CircleCollider2D>().isTrigger = false;
                gameManager.loveBallTwo.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
