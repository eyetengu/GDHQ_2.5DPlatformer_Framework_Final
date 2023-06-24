using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            other.transform.position= Vector3.zero;
            other.gameObject.SetActive(true);
        }
    }
}
