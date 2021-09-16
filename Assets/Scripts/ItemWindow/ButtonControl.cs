using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private ItemWindowControl _itemWindowControl;
    private ItemWindowSO _itemWindowSO;
    private List<AountOfCurency> _listPlayerCurrency;

    private void Awake()
    {
        _itemWindowControl = GetComponentInParent<ItemWindowControl>();
        _itemWindowSO = _itemWindowControl.GetItemWindow;
    }

    public void Buy(string nameCurrency)
    {
        _listPlayerCurrency = _itemWindowControl.GetListPlayerCurrency;
        List<AountOfCurency> allOptionsBuy = _itemWindowSO.WayToBuy;
        bool flagBuy = false;
        foreach (var optionsBuy in allOptionsBuy)
        {
            foreach (var playerCurrency in _listPlayerCurrency)
            {
                if (optionsBuy._currency.CurrecyName == nameCurrency && playerCurrency._currency.CurrecyName == nameCurrency)
                {
                    if (optionsBuy._aountOfCurency <= playerCurrency._aountOfCurency)
                    {
                        flagBuy = true;
                        _itemWindowControl.Buy(nameCurrency, optionsBuy._aountOfCurency);
                        Debug.Log(optionsBuy._aountOfCurency);
                        break;
                    }
                    else
                    {
                        Debug.Log("Insufficient funds");
                    }
                }
            }
            if (flagBuy)
                break;
        }
    }
}
