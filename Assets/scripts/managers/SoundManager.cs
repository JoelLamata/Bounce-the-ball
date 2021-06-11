using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource musicSource;

    public AudioClip bounceClip;
    public AudioClip basketClip;
    public AudioClip celebration;

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayBounceClip()
    {
        PlaySound(bounceClip);
    }

    public void PlayBasketClip()
    {
        PlaySound(basketClip);
        PlaySound(celebration);
    }

}
