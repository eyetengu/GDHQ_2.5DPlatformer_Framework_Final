using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _xCameraOffset = 15.0f;
    [SerializeField] private float _yCameraOffset = 5.0f;

    void Start()
    {
        _playerTransform = GameObject.Find("PlayerBase").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {        
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.transform.position = new Vector3(_xCameraOffset, _playerTransform.position.y + _yCameraOffset, _playerTransform.position.z);
    }
}
