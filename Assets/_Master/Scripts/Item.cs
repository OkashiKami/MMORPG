using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum ItemType { NONE = 000, Currency=001, Potion = 002, }
public class Item
{

    public string id { get; internal set; }
    public string name { get; internal set; }
    public bool stackable { get; internal set; }
    public int stack = 1;
    public int maxstacksize { get; internal set; }
    public ItemType type { get; internal set; }

    public Item (string name = "", bool stackable = true, int maxstacksize = 64, ItemType type = ItemType.NONE)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(UnityEngine.Random.Range(-1000, 1000).ToString());
        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        this.id = hashString.PadLeft(32, '0');
        this.name = name;
        this.stackable = stackable;
        this.maxstacksize = maxstacksize;
        this.type = type;
    }

    public void Execute()
    {

    }


    public string GetItemCode()
    {
        return type.GetHashCode().ToString();
    }
}
