using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public RectTransform mainMenu;
	public RectTransform optionsMenu;
	MenuEvents menuEvents;

	void OnEnable()
	{
		menuEvents = GetComponent<MenuEvents>();
		menuEvents.ChangeMenu.AddListener(SetActiveMenu);
	}

	void OnDisable()
	{
		menuEvents.ChangeMenu.RemoveListener(SetActiveMenu);
	}

	public void SetActiveMenu(ActiveMenu activeMenu)
	{
		switch (activeMenu)
		{
			case ActiveMenu.Main:
				mainMenu.SetAsLastSibling();
				break;
			case ActiveMenu.Options:
				optionsMenu.SetAsLastSibling();
				break;
			default:
				break;
		}
	}

}
