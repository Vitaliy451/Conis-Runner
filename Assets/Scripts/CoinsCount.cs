using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour
{
    public static CoinsCount instance;

    [SerializeField]
    Text coinText;

    private int currentCoin;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        coinText.text = "" + 0;
    }

    void Update()
    {
        
    }
    public void Increase()
    {
        currentCoin++;
        coinText.text = "" + currentCoin;
    }
}
