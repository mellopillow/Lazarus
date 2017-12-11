using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource musicSource;

    public static AudioManager instance = null;
    public AudioClip[] music;
    public AudioClip[] sfx;
    private bool playedMusic = false;




    void Awake()
    {
        //Debug.Log("Start");
        PlayMusicSource();
        //Check for AudioManager
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        
        //Use if you don't want to destroy between scenes.
        DontDestroyOnLoad(this.gameObject);

        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Main_Menu")
        {
            AudioManager.instance.StopMusic();
            AudioManager.instance.PlayMainMenu();
        }
        else
        {
            if (playedMusic == false)
            {
                AudioManager.instance.PlayTheme();
                playedMusic = true;
            }
        }


    }

    public void Update()
    {
        
    }

    public void PlaySFX()
    {
        sfxSource.Play();
    }

    public void PlayMusicSource()
    {
        musicSource.Play();
    }

    public void PlaySFXClip(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    //Note: AudioManager is set to only play one song at a time
    public void PlayMusic(AudioClip clip, float volume)
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayTheme()
    {
        PlayMusic(music[0], .9f);
    }

    public void PlayMainMenu()
    {
        PlayMusic(music[1], .9f);
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }

    //Warning: This will stop ALL currently playing SFX
    public void StopSFX()
    {
        if (sfxSource.isPlaying)
            sfxSource.Stop();
    }

    //Sets the master music volume where volume is a float in the range (0, 1.0)
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    //Sets the master SFX volume where volume is a float in the range (0, 1.0)
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    //Selects and plays a random clip from a given selection
    public void randomSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        sfxSource.PlayOneShot(clips[randomIndex]);
    }

    public void randomMusic(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length - 1);
        PlayMusic(clips[randomIndex], .9f);
    }

    public void playSFX1()
    {
        sfxSource.PlayOneShot(sfx[0]);
    }

    public void playSFX2()
    {
        sfxSource.PlayOneShot(sfx[1]);
    }

    public void playattack1()
    {
        sfxSource.PlayOneShot(sfx[2]);
    }

    public void playattack2()
    {
        sfxSource.PlayOneShot(sfx[3]);
    }

	public void soundfx(int pick,float vol)
	{
		sfxSource.PlayOneShot(sfx[pick], vol);
	}

}
