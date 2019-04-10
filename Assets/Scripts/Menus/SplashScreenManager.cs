using UnityEngine;

public class SplashScreenManager : MonoBehaviour {

    [Header("RESOURCES")]
    public GameObject mainPanels;
    public CanvasGroup topPanelCG;
    private Animator mainPanelsAnimator;

    [Header("SETTINGS")]
    public bool disableSplashScreen;

    /*void Start ()
    {
        if (disableSplashScreen == true)
        {
            mainPanels.SetActive(true);

            mainPanelsAnimator = mainPanels.GetComponent<Animator>();
            mainPanelsAnimator.Play("Main Panel Opening");
        }
    }*/

    public void OnTitleScreenDone()
    {
        if (disableSplashScreen == true)
        {
            mainPanels.SetActive(true);

            mainPanelsAnimator = mainPanels.GetComponent<Animator>();
            mainPanelsAnimator.Play("Main Panel Opening");
        }
    }

    public void OnReturnTitleScreen()
    {
        topPanelCG.alpha = 0;
        topPanelCG.interactable = false;
        topPanelCG.blocksRaycasts = false;
    }

    public void OnReturnMenu()
    {
        topPanelCG.alpha = 1;
        topPanelCG.interactable = true;
        topPanelCG.blocksRaycasts = true;
    }
}
