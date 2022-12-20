using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : SingletonMonoBehaviour<ShopManager>
{
    public List<ItemPrice> ItemPrices => _itemPrices;

    [SerializeField]
    [Header("’l’i")] 
    List<ItemPrice> _itemPrices = new();
}

[System.Serializable]
public class ItemPrice
{
    public string Explanation => _explanation;

    public int Price => _price;

    [SerializeField]
    string _explanation;

    [SerializeField]
    int _price;
}