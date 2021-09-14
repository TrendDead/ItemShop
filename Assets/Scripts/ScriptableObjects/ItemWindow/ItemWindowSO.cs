using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Window", menuName = "ScriptableObject/Item Window", order = 52)]
public class ItemWindowSO : ScriptableObject
{
    //public string ItemName;
    //public Sprite ItemSprite;

    public bool LimitedOffer;
    public int SaleTimeInSeconds;
    public List<PurchaseValue> WayToBuy;
}
