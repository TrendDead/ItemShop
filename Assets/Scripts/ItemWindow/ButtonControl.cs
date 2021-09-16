using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    private CurrencySO _currencyToBuy;
    private string _currecyName;

    private ItemWindowuBuyControl _itemWindowControl;
    private ItemWindowSO _itemWindowSO;
    private List<AountOfCurency> _listPlayerCurrency;
    private AountOfCurency _currency = null;

    private TMP_Text _veiwPrice;
    private void Awake()
    {
        _veiwPrice = GetComponentInChildren<TMP_Text>();
        _itemWindowControl = GetComponentInParent<ItemWindowuBuyControl>();
        _itemWindowSO = _itemWindowControl.GetItemWindow;
        _currecyName = _currencyToBuy.CurrecyName;
        List<AountOfCurency> allOptionsBuy = _itemWindowSO.WayToBuy;
        foreach (var optionsBuy in allOptionsBuy)
        {
            if (optionsBuy._currency.CurrecyName == _currecyName)
                _currency = optionsBuy;
        }
        _veiwPrice.text = _currecyName + ": " + _currency._aountOfCurency.ToString();
    }

    public void Buy()
    {
        _listPlayerCurrency = _itemWindowControl.GetListPlayerCurrency;
        bool flagBuy = false;
        bool wrong—urrency = false;
        for (int i = 0; i < _listPlayerCurrency.Count; i++)
        {
            AountOfCurency playerCurrency = _listPlayerCurrency[i];
            if (playerCurrency._currency.CurrecyName == _currecyName && _currency != null)
            {
                if (_currency._aountOfCurency <= playerCurrency._aountOfCurency)
                {
                    flagBuy = true;
                    _itemWindowControl.Buy(_currecyName, _currency._aountOfCurency);
                    break;
                }
                else
                {
                    Debug.Log("Insufficient funds");
                    break;
                }
            }
            else
                if (i == _listPlayerCurrency.Count - 1)
                {
                    wrong—urrency = true;
                }
        }
        if (wrong—urrency)
        {
            Debug.Log("This item cannot be purchased for the specified currency");
        }
        if (flagBuy)
        {
            GetComponentInParent<ItemWindowuTimeControl>().IsItemBuy();
        }
    }
}
