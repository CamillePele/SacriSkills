using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float activeTime;
    public bool active;

    private void FixedUpdate()
    {
        if (active) activeTime += Time.deltaTime;
    }
}