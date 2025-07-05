using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameController : MonoBehaviour
{


    private Transform selectedCard;
    private Vector2 _mousePos;

    bool _mouseLeftDown = false;

    [SerializeField] LayerMask layers;

    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerHand;

    CardHolder[] playerHandCardPos = new CardHolder[] { 
        new CardHolder(new Vector3(-1.80f, 0, 0)),
        new CardHolder(new Vector3(-0.60f, 0, 0)),
        new CardHolder(new Vector3(0.60f, 0, 0)),
        new CardHolder(new Vector3(1.80f, 0, 0)),
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerHandCardPos.Length; i++)
        {
            Instantiate(cardPrefab, playerHand);
            cardPrefab.transform.position = playerHandCardPos[i].pos;
            playerHandCardPos[i].holdingCard = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();

        if (_mouseLeftDown)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedCard.position = new Vector3(_mousePos.x, _mousePos.y,0f);
        }
    }

    void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
            if (hit && hit.collider.gameObject.layer == LayerMask.NameToLayer("Card"))
            {
                Debug.Log(hit.collider.gameObject.tag);
                selectedCard = hit.transform;
                _mouseLeftDown = true;
                //test = hit.point;
            }
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
            if (hit && hit.collider.gameObject.layer == LayerMask.NameToLayer("Card"))
            {
                Debug.Log(hit.collider.gameObject.tag);

                //test = hit.point;
            }
            _mouseLeftDown = false;
        }
    }
}


public struct CardHolder
{
    public Vector3 pos { get; set; }
    public bool holdingCard { get; set; }

    public CardHolder(Vector3 POS)
    {
        pos = POS;
        holdingCard = false;
    }
}