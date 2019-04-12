using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBackButton : MonoBehaviour {

    public TopPanelManager TopPanelManager;
    public ExitSettings ExitSettingsPanel;
    public SettingsMenu SettingsMenu;

	public void GoBack()
    {
        if (SettingsMenu.changesNotApplied)
        {
            ExitSettingsPanel.OpenExitChoiceMenu();
        }
        else
        {
            TopPanelManager.PanelAnim(0);
        }
    }
	
}
