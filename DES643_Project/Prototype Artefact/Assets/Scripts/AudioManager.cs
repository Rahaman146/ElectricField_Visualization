using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0f, 1f)]
    public float masterVolume = 1f;

    private AudioSource[] allSources;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 🔥 persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        ApplyVolume();
    }

    public void SetVolume(float volume)
    {
        masterVolume = volume;
        ApplyVolume();

        // Save value permanently
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void LoadVolume()
    {
        masterVolume = PlayerPrefs.GetFloat("Volume", 1f);
        ApplyVolume();
    }

    void ApplyVolume()
    {
        allSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in allSources)
        {
            source.volume = masterVolume;
        }
    }
}