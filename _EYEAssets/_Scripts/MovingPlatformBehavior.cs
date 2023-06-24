using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private bool _switching;
    [SerializeField] private float _step = 0.1f;

    
    void FixedUpdate()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (_switching == false)
        { 
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _step); 
        }
        else if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _step);
        }   

        if (transform.position == _pointB.position)
            _switching = true;

        if(transform.position == _pointA.position)
            _switching= false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}
