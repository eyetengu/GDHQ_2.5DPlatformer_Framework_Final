using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollZoneBehavior : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Player Recognized");
            _controller.height = 0.6f;
            _animator.SetTrigger("Roll");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _controller.height = 1.8f;            
        }
    }
}
