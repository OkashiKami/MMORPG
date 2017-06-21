using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum SkillType {  MountSummon_BigCat}
public class Skill
{
    public string id;
    public string name;
    public SkillType type;

    public Skill (string id, string name, SkillType type)
    {
        this.id = id;
        this.name = name;
        this.type = type;
    }    
}
