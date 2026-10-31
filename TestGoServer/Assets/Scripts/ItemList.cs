using System;
[Serializable]
public class ItemList
{
    public Item[] items;
}

[Serializable]
public class Item
{
    public int id;
    public string name;
}
