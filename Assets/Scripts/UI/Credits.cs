using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Credits : MonoBehaviour
{
    public UnityEvent onCreditEnd;
    public float maxZPos, speed;
    public GameObject textObj;
    public float maxTime;

    private Vector3 startPos;
    private bool isCreditLaunched;
    private float currenTime;

    private void Start()
    {
        startPos = textObj.transform.position;
        isCreditLaunched = false;
        currenTime = 0;
    }

    public void StartCredits()
    {
        textObj.transform.position = startPos;
        isCreditLaunched = true;
        currenTime = 0;
    }

    void Update()
    {
        if (isCreditLaunched)
        {
            currenTime += Time.deltaTime;
            float amount = speed * Time.deltaTime;
            textObj.transform.position += textObj.transform.up * amount;
            Debug.Log("avant");
            if (currenTime >= maxTime)
            {
                Debug.Log("aprés");
                isCreditLaunched = false;
                onCreditEnd.Invoke();
            }
        }
    }
}
