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

    [SerializeField]LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        
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
