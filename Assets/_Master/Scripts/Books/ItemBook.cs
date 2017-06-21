using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ItemBook : Book
{
    public override void Start()
    {
        title = "Item Book";
        type = BookType.Item;
    }

    public override void Update()
    {

    }
}