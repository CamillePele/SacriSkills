using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSelectEvent : MonoBehaviour, ISelectHandler
{
    [SerializeField] private UnityEvent onSelected;
    
    private Button _button;

    public void OnSelect(BaseEventData eventData)
    {
        onSelected.Invoke();
    }
}
