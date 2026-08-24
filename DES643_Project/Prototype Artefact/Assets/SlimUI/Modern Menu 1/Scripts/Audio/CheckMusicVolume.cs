using UnityEngine;

namespace SlimUI.ModernMenu
{
	public class CheckMusicVolume : MonoBehaviour
	{
		private static CheckMusicVolume instance;

		void Awake()
		{
			// Singleton pattern
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject); // 🔥 persists across scenes
			}
			else
			{
				Destroy(gameObject); // remove duplicates
			}
		}

		void Start()
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
		}

		public void UpdateVolume()
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
		}
	}
}