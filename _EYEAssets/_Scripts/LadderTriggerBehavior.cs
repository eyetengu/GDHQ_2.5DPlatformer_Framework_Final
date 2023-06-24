using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTriggerBehavior : MonoBehaviour
{
    [SerializeField] private Transform _otherEndOfLadder;
    [SerializeField] private bool _isReadyToClimb, _isClimbing;
    private Transform _playerTransform;
    private Animator _animator;
    private PlayerBehavior _playerBehavior;

    private void Start()
    {
        _playerTransform = GameObject.Find("PlayerBase").GetComponent<Transform>();
        _animator = GameObject.Find("Character_Explorer_Female_01").GetComponent<Animator>();
        //_animator.SetBool("Climb", true);
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        _playerBehavior._climbing = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _playerBehavior._climbing = false;

    }
}
