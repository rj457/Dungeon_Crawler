using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BattleResult : ScriptableObject
{
    public string enemyTag;
    public bool IsPlayerWin; 
}
