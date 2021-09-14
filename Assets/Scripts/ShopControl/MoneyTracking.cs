using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTracking : MonoBehaviour
{
    private AllCurrency _allCurrency;
    private List<AountOfCurency> _listCurrency;

    private void Awake()
    {
        _allCurrency = GetComponent<AllCurrency>();
        _listCurrency = _allCurrency.GetAllCurrency;
    }
}
