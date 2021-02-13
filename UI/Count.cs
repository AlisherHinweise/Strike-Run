using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    //private Text _text;
    public int coins = 0;
    private int _deadEnemies = 0;

    private void Start()
    {
        //_text = GetComponent<Text>();    
    }

    public void AddCoins()
    {
        _deadEnemies++;
        if(_deadEnemies % 2 == 0) coins = coins + 5;
        //_text.text = coins.ToString();
    }
}
