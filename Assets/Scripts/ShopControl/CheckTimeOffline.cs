using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeOffline : MonoBehaviour
{
    private void Awake()
    {
        CheckOffine();
    }

    public DateTime CheckOffine()
    {
        DateTime _firstRunTime = DateTime.Now;
        if (PlayerPrefs.HasKey("FirstSassion"))
        {
            _firstRunTime = DateTime.Parse(PlayerPrefs.GetString("FirstSassion"));
        }
        return _firstRunTime;
    }

}
