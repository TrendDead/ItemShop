using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindowuBuyControl : MonoBehaviour
{
    [SerializeField]
    private ItemWindowSO _itemWindowSO;

    [SerializeField]
    private AfterBuy _buttonSistemAfterBuy;
    private BeforeBuy _buttonSistemBeforeBuy;

    private MoneyTracking _moneyTracking;
    private List<AountOfCurency> _listCurrency;

    public ItemWindowSO GetItemWindow => _itemWindowSO;
    public List<AountOfCurency> GetListPlayerCurrency => _listCurrency;

    private void Awake()
    {
        _moneyTracking = FindObjectOfType<MoneyTracking>();
        _buttonSistemBeforeBuy = GetComponentInChildren<BeforeBuy>();
    }

    private void OnEnable()
    {
        _moneyTracking.UpdateDataCurrency += UpdateListCurrency;
    }

    private void OnDisable()
    {
        _moneyTracking.UpdateDataCurrency -= UpdateListCurrency;
    }

    private void UpdateListCurrency(List<AountOfCurency> listCurrency)
    {
        _listCurrency = listCurrency;
    }

    public void Buy(string nameCurrency, float purchasePrice)
    {
        _moneyTracking.UpdateData(nameCurrency, purchasePrice);
        _buttonSistemBeforeBuy.gameObject.SetActive(false);
        _buttonSistemAfterBuy.gameObject.SetActive(true);
    }

    public void IsTimeOut()
    {
        _buttonSistemBeforeBuy.gameObject.SetActive(false);
        _buttonSistemAfterBuy.gameObject.SetActive(false);
    }

}
