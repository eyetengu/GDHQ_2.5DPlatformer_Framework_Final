using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTriggerBehavior : MonoBehaviour
{
    //ladder has a ladder visual and two trigger volumes(one low and one high)
    //when the player enters the low trigger volume
    //-charactercontroller disabled
    //-if player presses W or S the character will climb up or down
    //-play climbing animation(loop)
    //if the player enters the high trigger volume
    //-the player finish climb animation will play and
    //-the player will snap to a finished climbing position
    //-the CharacterController will be re-enabled

    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerBehavior _playerBehavior;

    public bool _hasReachedPointB;
    [SerializeField] private Transform _finalRestingPlace;

    [SerializeField] private Transform _otherEndOfLadder;
    [SerializeField] private bool _rise = false;
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _controller = GameObject.Find("PlayerBase").GetComponent<CharacterController>();
        _animator = GameObject.Find("Explorer").GetComponent<Animator>();
        _playerTransform = GameObject.Find("PlayerBase").GetComponent<Transform>();
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
        _finalRestingPlace = GameObject.Find("FinalRestingPlace").GetComponent<Transform>();
    }

    private void Update()
    {
        if(_hasReachedPointB == true)
        {
            Debug.Log("Player Has REB");
            _playerTransform.position = _finalRestingPlace.transform.position;
            _controller.enabled = true;
            _hasReachedPointB = false;
            _playerBehavior._climbing = false;
            _animator.SetBool("Climb", false);
            _animator.SetFloat("Speed", 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerBehavior._climbing = true; 
            _controller.enabled= false;
            //_animator.SetBool("Climb", true);
            _animator.Play("ClimbEnter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
