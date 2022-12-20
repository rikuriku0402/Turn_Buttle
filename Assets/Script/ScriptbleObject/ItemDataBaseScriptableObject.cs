using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDataBase",menuName ="CreateItemDataBase")]
public class ItemDataBaseScriptableObject : ScriptableObject
{
    [SerializeField]
    List<Item> _ItemList = new();

    public List<Item> GetItemLists() => _ItemList;
}
