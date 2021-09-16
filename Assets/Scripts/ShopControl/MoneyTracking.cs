using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyTracking : MonoBehaviour
{
    private AllCurrency _allCurrency;
    private List<AountOfCurency> _listCurrency;
    
    public event UnityAction<List<AountOfCurency>> UpdateDataCurrency;

    private void Awake()
    {
        _allCurrency = GetComponent<AllCurrency>();
        _listCurrency = _allCurrency.GetAllCurrency;
    }

    private void Start()
    {
        UpdateDataCurrency?.Invoke(_listCurrency);
    }

    public void UpdateData(string nameCurrency, float purchasePrice)
    {
        foreach (var currency in _listCurrency)
        {
            if (currency._currency.CurrecyName == nameCurrency)
                currency._aountOfCurency -= purchasePrice;
        }
        UpdateDataCurrency?.Invoke(_listCurrency);
    }
}
