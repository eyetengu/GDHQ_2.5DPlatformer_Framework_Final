using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBehavior : MonoBehaviour
{
    private bool _switching;
    [SerializeField] private Transform _pointA, _pointB;
    [SerializeField] private float _step;
    [SerializeField] private bool _pauseLift;

    void Start()
    {
    }

    void Update()
    {
        if (_pauseLift == false)
        {
            MovePlatform();
        }
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
        {
            _switching = true;
            _pauseLift= true;
            StartCoroutine(LiftTiming());
        }

        if (transform.position == _pointA.position)
        {
            _switching = false;
            _pauseLift = true;
            StartCoroutine(LiftTiming());
        }
    }

    IEnumerator LiftTiming()
    {
        yield return new WaitForSeconds(5);
        _pauseLift = false;
    }

}
