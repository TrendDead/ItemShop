using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField]
    private AllItems _allItems;
    [SerializeField]
    private AllCurrency _allCurrency;

    private Item[] _items;
    private List<AountOfCurency> _aountOfCurencies;

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }

    private void Save()
    {
        _items = _allItems.Items;
        _aountOfCurencies = _allCurrency.GetAllCurrency;
        foreach (var item in _items)
        {
            bool isBuy = item.GetComponent<ItemWindowuBuyControl>().IsItemBuy;
            int boolInt = isBuy ? 1 : 0;
            PlayerPrefs.SetInt(item.name, boolInt);
        }
        foreach (var curencies in _aountOfCurencies)
        {
            PlayerPrefs.SetFloat(curencies._currency.CurrecyName, curencies._aountOfCurency);
        }
        PlayerPrefs.SetString("LastSassion", DateTime.Now.ToString());
        DeleteSvae();
    }

    private void DeleteSvae()
    {
        PlayerPrefs.DeleteAll();
    }
}
