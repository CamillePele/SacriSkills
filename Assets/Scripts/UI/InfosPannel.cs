using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfosPannel : MonoBehaviour
{

    [CanBeNull][SerializeField] private CompétenceDatas startCompétence;
    [SerializeField] private TMP_Text titre;
    [SerializeField] private TMP_Text inputs;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;

    public void Start()
    {
        if(startCompétence != null)SetupInfos(startCompétence);
    }
    public void SetupInfos(CompétenceDatas datas)
    {
        titre.text = datas.titre;
        inputs.text = datas.methodInput;
        description.text = datas.description;
        icon.sprite = datas.icon;
    }
}
