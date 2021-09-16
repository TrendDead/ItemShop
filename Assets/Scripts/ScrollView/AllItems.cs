using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    private Item[] _items;

    public Item[] Items => _items;

    private void Start()
    {
        _items = GetComponentsInChildren<Item>();
    }
}
