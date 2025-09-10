using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;   // Həmişə çalacaq fon musiqisi
    public AudioSource sfxSource1;    // Effekt səsi 1
    public AudioSource sfxSource2;
    public AudioSource sfxSource3;    // Effekt səsi 2

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip effect1;
    public AudioClip effect2;
     public AudioClip effect3;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Fon musiqisi həmişə çalsın
        PlayMusic();
    }

    // 🎵 Fon musiqisi
    public void PlayMusic()
    {
        if (backgroundMusic == null) return;
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // 🔊 Effekt 1 Start/Stop
    public void PlayEffect1()
    {
        if (effect1 == null) return;
        if (!sfxSource1.isPlaying)
        {
            sfxSource1.clip = effect1;
            sfxSource1.loop = false;  // loop etmək istəyirsənsə
            sfxSource1.Play();
        }
    }

    public void StopEffect1()
    {
        if (sfxSource1.isPlaying)
            sfxSource1.Stop();
    }

    // 🔊 Effekt 2 Start/Stop
    public void PlayEffect2()
    {
        if (effect2 == null) return;
        if (!sfxSource2.isPlaying)
        {
            sfxSource2.clip = effect2;
            sfxSource2.loop = false;  // loop etmək istəyirsənsə
            sfxSource2.Play();
        }
    }

    public void StopEffect2()
    {
        if (sfxSource2.isPlaying)
            sfxSource2.Stop();
    }

        public void PlayEffect3()
    {
        if (effect3 == null) return;
        if (!sfxSource3.isPlaying)
        {
            sfxSource3.clip = effect2;
            sfxSource3.loop = false;  // loop etmək istəyirsənsə
            sfxSource3.Play();
        }
    }

    public void StopEffect3()
    {
        if (sfxSource3.isPlaying)
            sfxSource3.Stop();
    }
}
