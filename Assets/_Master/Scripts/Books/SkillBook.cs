using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class SkillBook : Book
{
    public override void Start()
    {
        title = "Skill Book";
        type = BookType.Skill;
    }

    public override void Update()
    {

    }
}