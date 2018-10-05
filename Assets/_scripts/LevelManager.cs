using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public const string level01name = "Level01";

	private void OnEnable()
	{
		MenuEvents.Instance.StartPlaying.AddListener(ChangeScene);
	}

	private void OnDisable()
	{		
		MenuEvents.Instance?.StartPlaying.RemoveListener(ChangeScene);
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene(level01name);
	}	
}