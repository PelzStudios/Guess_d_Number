using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource bgMusicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip bgMusicClip;
    public AudioClip buttonClickSound;
    public AudioClip winGameSound;
    public AudioClip gameOverSound;
    public AudioClip cardTapSound;

    void Awake()
    {
        PlayMusic(bgMusicClip);
    }

    void OnEnable()
    {
        GameEvents.OnGameWon += () => PlaySFX(winGameSound);
        GameEvents.OnCardTapped += () => PlaySFX(cardTapSound);
        GameEvents.OnGameOver += () => PlaySFX(gameOverSound);
    }

    void OnDisable()
    {
        GameEvents.OnGameWon -= () => PlaySFX(winGameSound);
        GameEvents.OnCardTapped -= () => PlaySFX(cardTapSound);
        GameEvents.OnGameOver -= () => PlaySFX(gameOverSound);
    }

    

    public void PlayMusic(AudioClip clip)
    {
        bgMusicSource.clip = clip;
        bgMusicSource.loop = true;
        bgMusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickSound);
    }

}