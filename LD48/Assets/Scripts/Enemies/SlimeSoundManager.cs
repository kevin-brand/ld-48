using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] SlimeClips;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SoundLoop();
    }

    private void SoundLoop()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_source.isPlaying)
        {
            _source.clip = SlimeClips[Random.Range(0, SlimeClips.Length)];
            _source.PlayDelayed(Random.Range(10, 25) / 10);
        }
    }
}
