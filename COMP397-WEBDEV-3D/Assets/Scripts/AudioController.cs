using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    //private void Start()
    //{
    //    PlayBGMusic();

    //}

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        PlayBGMusic();
    }

    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();


    }

    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();


    }

    public void PlayBGMusic()
    {

        musicSource.clip = backgroundMusic;
        musicSource.Play();

    }
}
