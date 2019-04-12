using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSettings : MonoBehaviour {

    public TopPanelManager TopPanelManager;
    public SettingsMenu SettingsMenu;

	public void GoMainMenu()
    {
        TopPanelManager.PanelAnim(0);
    }

    public void GoSettings()
    {
        GetComponent<Animator>().Play("ExitToSettings");
    }

    public void GoSettingsAndMenu()
    {
        SettingsMenu.RevertChanges();
        GetComponent<Animator>().Play("ExitToMenu");
    }

    public void OpenExitChoiceMenu()
    {
        GetComponent<Animator>().Play("YouWantToExitIn");
    }
}
