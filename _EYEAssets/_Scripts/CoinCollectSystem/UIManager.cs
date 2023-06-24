using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCollectedText;
    private int _coinsCollected = 0;

   
    public void AddCoins()
    {
        _coinsCollected++;
        _coinsCollectedText.text = "Score: " + _coinsCollected.ToString();
    }
}
