using UnityEngine;

public class SplashScreenManager : MonoBehaviour {

    [Header("RESOURCES")]
    public GameObject mainPanels;
    private Animator mainPanelsAnimator;

    [Header("SETTINGS")]
    public bool disableSplashScreen;

    void Start ()
    {
        if (disableSplashScreen == true)
        {
            mainPanels.SetActive(true);

            mainPanelsAnimator = mainPanels.GetComponent<Animator>();
            mainPanelsAnimator.Play("Main Panel Opening");
        }
    }
}
