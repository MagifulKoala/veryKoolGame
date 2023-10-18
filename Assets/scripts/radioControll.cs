using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioControll : MonoBehaviour
{
    [SerializeField] AudioClip song1;
    [SerializeField] AudioClip song2;
    [SerializeField] AudioClip song3;
    AudioSource transmiAudioSource;

    int currentSong = 0;

    void Start()
    {
        transmiAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("radio triggered");
            switch (currentSong)
            {
                case 0:
                    transmiAudioSource.Stop();
                    break;
                case 1:
                    transmiAudioSource.Stop();
                    transmiAudioSource.PlayOneShot(song1);
                    break;
                case 2:
                    transmiAudioSource.Stop();
                    transmiAudioSource.PlayOneShot(song2);
                    break;
                case 3:
                    transmiAudioSource.Stop();
                    transmiAudioSource.PlayOneShot(song3);
                    break;

            }
            currentSong++;
            if (currentSong > 3)
            {
                currentSong = 0;
            }
        }
    }
}
