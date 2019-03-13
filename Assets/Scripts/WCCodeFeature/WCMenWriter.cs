using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCMenWriter : Interactable {

    private List<int> _inputList;
    private SoundsManager _toiletSoundsManager;
    private AudioSource _toiletSource;
    private WCCodeFeature _wCCodeFeature;

    public override void Interact()
    {
        if(_wCCodeFeature.Counter > _wCCodeFeature._flushDelay)
        {
            base.Interact();
            AddMaleCode();
        }
    }

    private void Awake()
    {
        _wCCodeFeature = GetComponentInParent<WCCodeFeature>();
        _inputList = GetComponentInParent<WCCodeFeature>().PlayerInput;
        _toiletSoundsManager = SoundsManager.instance;
    }

    private void AddMaleCode()
    {
        _toiletSoundsManager.PlaySFX(_toiletSoundsManager.ToiletFlush);
        GetComponentInParent<WCCodeFeature>().Counter = 0;
        _inputList.Add(0);
    }
}
