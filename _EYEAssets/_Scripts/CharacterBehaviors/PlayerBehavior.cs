using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private CharacterController _controller;
    private AudioManager _audioManager;

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;

    private float _yVelocity;
    private bool _canDoubleJump;

    [SerializeField] private Transform _deadZoneTransform;
    [SerializeField] private Transform _respawnTransform;


    void Start()
    {
        _controller = GetComponent<CharacterController>();  
        _audioManager = FindObjectOfType<AudioManager>();      
    }

    void Update()
    {        
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(0,0,horizontalInput);
        Vector3 velocity = direction * _speed;
        
        if (_controller.isGrounded == true)
        {
            Debug.Log("Grounded");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _audioManager.PlayAudioOfChoice(1);

                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }

        else
        {
            Debug.Log("Not Grounded");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _audioManager.PlayAudioOfChoice(1);
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
