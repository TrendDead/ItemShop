using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewContentAdapter : MonoBehaviour
{
    private GridLayoutGroup _gridLayout;
    private void Awake()
    {
        _gridLayout = GetComponent<GridLayoutGroup>();
    }
    private void Start()
    {
        float width = Screen.width;     
        _gridLayout.constraintCount = (int)(width / 140);  
    }
}
