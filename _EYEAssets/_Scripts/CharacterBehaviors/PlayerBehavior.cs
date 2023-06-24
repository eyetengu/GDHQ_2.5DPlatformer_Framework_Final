using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Animator _animator;

    private AudioManager _audioManager;

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 1.0f;
    [SerializeField] private float _jumpHeight = 15.0f;

    private float _yVelocity;
    private bool _canDoubleJump;
    public bool _climbing;

    [SerializeField] private Transform _deadZoneTransform;
    [SerializeField] private Transform _respawnTransform;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = FindObjectOfType<Animator>();

        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (_climbing == true)
            Debug.Log("Climbing");
        else
            Debug.Log("Not Climbing");
            //ClimbLadder();

        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(0, 0, horizontalInput);
        Vector3 velocity = direction * _speed;

        if(horizontalInput != 0)
        {
            Debug.Log(velocity);
            Vector3 facing = transform.localEulerAngles;
            facing.y = velocity.z > 0 ? 0 : 180;
            transform.localEulerAngles = facing;
        }

        if (_controller.isGrounded == true)
        {
            //Debug.Log("Grounded");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _audioManager.PlayAudioOfChoice(1);

                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }

        else
        {
            //Debug.Log("Not Grounded");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
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
        if (velocity.z < -0.1f || velocity.z > 0.1f)
        {
            _animator.SetFloat("Speed", 0.15f);
        }
        else if (velocity.z > -0.1f || velocity.z < 0.1f)
        { 
            _animator.SetFloat("Speed", 0);
        }
    }

    public void ClimbLadder()
    {        
        transform.Translate(0, 0.1f, 0);
        _animator.SetBool("Climb", true);
    }

}
