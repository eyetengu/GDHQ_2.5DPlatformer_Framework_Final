using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenIdolBehavior : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameObject _visualEffect;
    [SerializeField] private GameObject _badguy;
    [SerializeField] private Transform _badGuySpawn;
    [SerializeField] private AudioSource _musicManager;
    [SerializeField] private AudioClip _tropicalClip;
    [SerializeField] private bool _hasNotPlayed;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _musicManager = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        _hasNotPlayed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(_hasNotPlayed == true)
            {
                _hasNotPlayed = false;

                _badguy.transform.position = _badGuySpawn.transform.position;
                _visualEffect.SetActive(true);

                StartCoroutine(BadGuyAppears());
            }
        }
    }
    IEnumerator BadGuyAppears()
    {
        _musicManager.PlayOneShot(_tropicalClip);
        yield return new WaitForSeconds(2);
        _badguy.SetActive(true);
        _visualEffect.SetActive(false);
    }
}
