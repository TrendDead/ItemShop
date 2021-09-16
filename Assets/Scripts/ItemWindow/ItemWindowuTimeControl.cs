using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemWindowuTimeControl : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _viewTime;

    [SerializeField]
    private Image _imageTimeOff;

    [SerializeField]
    private CheckTimeOffline _checkTimeOffline;

    private ItemWindowSO _itemWindowSO;
    private bool _activeTime = true;

    private TimeSpan _tameLeft;
    private TimeSpan _timeCurrencyActive;
    private TimeSpan _lastSassion;
    private DateTime _lastRunTime;

    private bool _isItemBuy = false;


    private void Awake()
    {
        _lastRunTime = DateTime.Now;
           _itemWindowSO = GetComponent<ItemWindowuBuyControl>().GetItemWindow;
        if (!_itemWindowSO.LimitedOffer)
        {
            _viewTime.gameObject.SetActive(false);
            _activeTime = false;
        }
        else
        if (PlayerPrefs.HasKey("LastSassion"))
        {
            _lastSassion = _checkTimeOffline.CheckOffine();
        }
        _tameLeft = TimeSpan.FromSeconds((double)(new decimal(_itemWindowSO.SaleTimeInSeconds)));
    }

    private void Start()
    {
        _isItemBuy = PlayerPrefs.GetInt(gameObject.name) == 1 ? true : false;
        if (_isItemBuy)
        {
            ItemBuy();
        }
    }

    private void Update()
    {
        if (_itemWindowSO.LimitedOffer && !_isItemBuy)
        {
            //Debug.Log(_lastRunTime.Second); //59 => 28
            //Debug.Log(_lastSassion.TotalSeconds); //4 => 7
            //Debug.Log(_tameLeft); //4 => 7
            //Debug.Log(_lastRunTime - DateTime.Now); //4 => 7
            _timeCurrencyActive = _tameLeft + ((_lastRunTime - (DateTime.Now + _lastSassion)));
            if (_timeCurrencyActive.TotalSeconds > 0)
                _viewTime.text = (string.Format("Time left: {0}:{1}:{2}", _timeCurrencyActive.Hours, _timeCurrencyActive.Minutes, _timeCurrencyActive.Seconds));
            else
            if (_activeTime)
            {
                _activeTime = false;
                TimeOut();
            }
        }
        else
        {
            _activeTime = false;
        }
        
    }

    private void TimeOut()
    {
        _viewTime.text = "Time out";
        _imageTimeOff.gameObject.SetActive(true);
        GetComponent<ItemWindowuBuyControl>().IsTimeOut();
    }

    public void ItemBuy()
    {
        _viewTime.gameObject.SetActive(true);
        _isItemBuy = true;
        _viewTime.text = "Use Item";
    }
}
