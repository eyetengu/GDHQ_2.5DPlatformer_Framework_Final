using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private float _coinSpeed = 10;
    [SerializeField] private GameObject _sparks;


    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        RotateCoin();
    }

    void RotateCoin()
    {
        transform.Rotate(0, 1 * _coinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _uiManager.AddCoins();
            _audioManager.PlayAudioOfChoice(0);
            _sparks.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
