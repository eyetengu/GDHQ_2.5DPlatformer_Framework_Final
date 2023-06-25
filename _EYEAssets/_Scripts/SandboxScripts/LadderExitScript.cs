using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderExitScript : MonoBehaviour
{
    [SerializeField] private LadderTriggerBehavior _ladderScript;


    private void Start()
    {
        _ladderScript = FindObjectOfType<LadderTriggerBehavior>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Has REached Ladder point b");
            _ladderScript._hasReachedPointB = true;
        }
    }
}
