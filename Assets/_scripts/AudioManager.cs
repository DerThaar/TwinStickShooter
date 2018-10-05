using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	AnimationCurve volCurve;
	[SerializeField]
	AudioMixer mainMixer;
	[SerializeField]
	AudioClip[] audioClips;
	AudioSource musicSource;
	int maxMusicIndex;
	int musicIndex = 1;

	void Awake()
	{
		musicSource = GetComponentInChildren<Tag_MusicSource>().GetComponent<AudioSource>();		
	}

	void OnEnable()
	{
		MenuEvents.Instance.NextTrack.AddListener(OnNextTrack);
		MenuEvents.Instance.PrevTrack.AddListener(OnPrevTrack);
		MenuEvents.Instance.ChangeVolume.AddListener(OnChangeVolume);
		MenuEvents.Instance.PrintVolToUnityVal.AddListener(PrintUnitValFromVolume);
	}

	void Start()
	{
		maxMusicIndex = audioClips.Length - 1;
		musicSource.clip = audioClips[musicIndex];
		musicSource.Play();
	}

	void OnNextTrack()
	{
		musicIndex++;

		if(musicIndex > maxMusicIndex)
		{
			musicIndex = 0;
		}

		musicSource.Stop();
		musicSource.clip = audioClips[musicIndex];
		musicSource.Play();
	}

	void OnPrevTrack()
	{
		musicIndex--;

		if (musicIndex < 0)
		{
			musicIndex = maxMusicIndex;
		}

		musicSource.Stop();
		musicSource.clip = audioClips[musicIndex];
		musicSource.Play();
	}

	void OnChangeVolume(float vol)
	{
		float t = volCurve.Evaluate(vol);
		float volume = Mathf.Lerp(-80, 0, t);
		mainMixer.SetFloat("MusicVolume", volume);
	}

	void PrintUnitValFromVolume()
	{
		float vol = 0;
		mainMixer.GetFloat("MusicVolume", out vol);
		//Utils.Map(vol, -80f, 0f, 0f, 1f);
		vol = Utils.Map(vol, -80f, 0f, 0f, 1f);
		Debug.Log(vol.ToString());
	}
}
