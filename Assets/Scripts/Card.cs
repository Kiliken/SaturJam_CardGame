using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public int seed;
    public int value;

    void Start()
    {
        seed = Random.Range(0, 4);
        value = Random.Range(1, 11);
    }
    
}
