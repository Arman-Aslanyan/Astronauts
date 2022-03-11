using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//grants access to the mixer
using UnityEngine.Audio;
public class RandomContainer : MonoBehaviour
{
    public AudioClip[] walkClips;
    public AudioClip[] jumpClips;
    public AudioClip[] oxyClips;
    private List<AudioClip> toPlay = new List<AudioClip>();
    public AudioMixerGroup output;
    public float minPitch = 0.75f;
    public float maxPitch = 1.25f;

    public void PlaySound(bool noPitchVar)
    {
        //randomize within the array length
        int randomClip = Random.Range(0, toPlay.Count);
        //create audiosource
        AudioSource source = gameObject.GetComponent<AudioSource>();
        //load clip into audiosource
        source.clip = toPlay[randomClip];
        //set output for audiosource
        source.outputAudioMixerGroup = output;
        if (noPitchVar)
        {
            //for sounds with no pitch variation
            source.pitch = 1;
        }
        else
        {
            //otherwise set pitch variation
            source.pitch = Random.Range(minPitch, maxPitch);
        }

        //play clip
        source.Play();
        toPlay.Clear();
    }

    public void StopSound()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.Stop();
    }

    public void PlayWalkClips()
    {
        SetClipsToPlay(0);
    }

    public void PlayJumpClips()
    {
        SetClipsToPlay(1);
    }

    public void PlayLowOxyClips()
    {
        SetClipsToPlay(2);
    }

    public void SetClipsToPlay(int num)
    {
        if (num == 0)
        {
            foreach (AudioClip clip in walkClips)
                toPlay.Add(clip);
        }
        else if (num == 1)
        {
            foreach (AudioClip clip in jumpClips)
                toPlay.Add(clip);
        }
        else if (num == 2)
        {
            toPlay.Add(oxyClips[0]);
        }
    }
}