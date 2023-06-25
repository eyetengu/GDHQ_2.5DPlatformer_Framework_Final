using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLadderScript : MonoBehaviour
{
    [SerializeField] private bool _rise =  false;
    [SerializeField] private GameObject _player;

    private void Update()
    {
        if (_rise == true)
            _player.transform.Translate(Vector3.up * Time.deltaTime);
            
    }


    private void OnTriggerEnter(Collider other)
    {
        
            _rise = true;
        
    }
}
