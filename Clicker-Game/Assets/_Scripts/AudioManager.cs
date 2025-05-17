using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> clickSounds = new List<AudioClip>();

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Clicker.Instance.OnClickerPressed += Clicker_OnClickerPressed;
    }

    private void Clicker_OnClickerPressed()
    {
        _audioSource.PlayOneShot(clickSounds[Random.Range(0, clickSounds.Count)], 10f);
    }
}
