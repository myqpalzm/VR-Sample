using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button, IPointerEnterHandler
{
    protected override void Awake()
    {
        base.Awake();
        AkSoundEngine.RegisterGameObj(gameObject);
    }
    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        AkSoundEngine.PostEvent("sfx_ui_button_onHover", gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.05f, 0.05f);
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        LeanTween.scale(gameObject, Vector3.one, 0.05f);
    }
}
