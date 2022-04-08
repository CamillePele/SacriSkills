using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class SetCompétence : MonoBehaviour, ISelectHandler
{
    [SerializeField] private Image image;
    [SerializeField] private InfosPannel _infosPannel;

    private CompétenceDatas _datas;
    public void SetImage(CompétenceDatas datas)
    {
        image.sprite = datas.icon;
        _datas = datas;
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        _infosPannel.SetupInfos(_datas);
    }
}
