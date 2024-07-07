using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip musicClip;

    void Awake()
    {
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject); 
            return;
        }

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusic();
    }


    public void PlayMusic()
    {
        if (audioSource.clip != musicClip)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
