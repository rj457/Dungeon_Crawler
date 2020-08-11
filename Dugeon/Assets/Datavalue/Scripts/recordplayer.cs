using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class recordplayer : ScriptableObject
{
    public bool IsLost;
    public bool Isescape;
    public bool Iswin;

    public static int playerhealth=100;
    public bool IsShield;
    public bool IsFollow; 
}
