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

    public TimeSpan CheckOffine()
    {
        TimeSpan ts = TimeSpan.Zero;
        if (PlayerPrefs.HasKey("LastSassion"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSassion"));
        }
        return ts;
    }

}
