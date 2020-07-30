﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryObject : ScriptableObject
{
    public int uninfectedallies;
    public int infectedallies;
    public bool alliesisfollow;
    public bool allies1isfollow;
    public List<string> enemyTag;
    //battle position
    public Vector3 initialvalue;
    public bool Isbattle;
    public Vector3 allies;
    public Vector3 allies1;

    public Vector3 alliesinitialvalue = new Vector3(-10.51F, -4.37F, -1F);
    public Vector3 allies1initialvalue = new Vector3(10.47F, 3.59F, -1F);
}
