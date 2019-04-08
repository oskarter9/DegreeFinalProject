using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIElementSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;

    private bool enableHoverSound;
    private bool enableClickSound;

    private AudioSource HoverSource { get { return GetComponent<AudioSource>(); } }
    private AudioSource ClickSource { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        if (GetComponent<Button>().interactable)
        {
            enableHoverSound = true;
            enableClickSound = true;
        }
        gameObject.AddComponent<AudioSource>();
        HoverSource.clip = hoverSound;
        ClickSource.clip = clickSound;

        HoverSource.playOnAwake = false;
        ClickSource.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(enableHoverSound == true)
        {
            HoverSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (enableClickSound == true)
        {
            ClickSource.PlayOneShot(clickSound);
        }
    }
}
