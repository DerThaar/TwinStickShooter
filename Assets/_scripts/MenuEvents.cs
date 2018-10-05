using UnityEngine;
using UnityEngine.Events;

public class MenuEvents : MonoBehaviour
{
	public UnityEvent StartPlaying = new UnityEvent();
	public UnityEvent<ActiveMenu> ChangeMenu = new ActiveMenuEvent();
	public UnityEvent<float> ChangeVolume = new FloatEvent();
	public UnityEvent PrevTrack = new UnityEvent();
	public UnityEvent NextTrack = new UnityEvent();
	public UnityEvent PrintVolToUnityVal = new UnityEvent();

	private static MenuEvents instance;
	public static MenuEvents Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<MenuEvents>();
			}

			return instance;
		}
		private set { instance = value; }
	}


	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}


	public void MainMenuButton()
	{
		ChangeMenu.Invoke(ActiveMenu.Main);
	}

	public void OptionsButton()
	{
		ChangeMenu.Invoke(ActiveMenu.Options);
	}

	public void PlayButton()
	{
		StartPlaying.Invoke();
	}

	public void VolumeSlider(float vol)
	{
		ChangeVolume.Invoke(vol);
	}

	public void VolToUnitValButton()
	{
		PrintVolToUnityVal.Invoke();
	}

	public void NextTrackButton()
	{
		NextTrack.Invoke();
	}

	public void PrevTrackButton()
	{
		PrevTrack.Invoke();
	}
}

public enum ActiveMenu
{
	Main = 0,
	Options = 1
}

[System.Serializable]
public class ActiveMenuEvent : UnityEvent<ActiveMenu>
{

}

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{

}
