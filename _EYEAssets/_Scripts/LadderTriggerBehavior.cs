using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTriggerBehavior : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Transform _otherEndOfLadder;
    [SerializeField] private bool _isReadyToClimb;
    private Transform _playerTransform;


    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _playerTransform = GameObject.Find("PlayerBase").GetComponent<Transform>();
    }
    private void Update()
    {
        if (_isReadyToClimb)
            if (Input.GetKeyDown(KeyCode.E))
            {
                _playerTransform.gameObject.SetActive(false);
                _playerTransform.position = _otherEndOfLadder.position;
                _audioManager.PlayAudioOfChoice(2);
                _playerTransform.gameObject.SetActive(true);
            }
    }






    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("What the what?");
        _isReadyToClimb = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            _isReadyToClimb= false;
    }
}
