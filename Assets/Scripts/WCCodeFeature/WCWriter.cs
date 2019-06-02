using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCWriter : Interactable {

    public int CodeToInput;

    private List<int> _inputList;
    private SoundsManager _toiletSoundsManager;
    private WCCodeFeature _wCCodeFeature;

    public override void Interact()
    {
        if(_wCCodeFeature.Counter > _wCCodeFeature._flushDelay)
        {
            base.Interact();
            AddCode();
        }
    }

    private void Awake()
    {
        _wCCodeFeature = GetComponentInParent<WCCodeFeature>();
        _inputList = GetComponentInParent<WCCodeFeature>().PlayerInput;
        _toiletSoundsManager = SoundsManager.instance;
    }

    private void AddCode()
    {
        _toiletSoundsManager.PlaySFX(_toiletSoundsManager.SFXPuzzleTwoSource, _toiletSoundsManager.ToiletFlush);
        GetComponentInParent<WCCodeFeature>().Counter = 0;
        _inputList.Add(CodeToInput);
    }
}
