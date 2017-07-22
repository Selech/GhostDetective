using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClueList", menuName = "ScriptableObject/ClueList", order = 1)]
public class ClueScriptableObject : ScriptableObject
{
    public List<Clue> List;
}

[System.Serializable]
public class Clue
{
    public string ClueTitle;
    public string ClueTextHint1;
    public string ClueTextHint2;
    public string ClueTextHint3;
    public string CorrespondingObjectName;
}

[CreateAssetMenu(fileName = "NamesList", menuName = "ScriptableObject/NamesList", order = 2)]
public class NamesScriptableObject : ScriptableObject
{
    public List<string> List;
}