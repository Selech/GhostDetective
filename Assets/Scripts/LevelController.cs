using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private List<int> UsedClues;
    private string currentName;
    private List<char> UnlockedLetters;

    [HideInInspector]
    public List<char> RemainingLetters;

    // Use this for initialization
    void Start () {
        currentName = Statics.PlayerPrefsStrings.CurrentName;
        UsedClues = Statics.PlayerPrefsStrings.UsedCluesList;
        UnlockedLetters = Statics.PlayerPrefsStrings.UnlockedLetters;

        RemainingLetters = new List<char>();
        var letters = currentName.ToList();
        foreach (var letter in UnlockedLetters)
        {
            letters.Remove(letter);
        }
        RemainingLetters = letters;
    }

    public int RandomClue(int max)
    {
        var clues = new List<int>();
        for(int i = 0; i < max; i++)
        {
            clues.Add(i);
        }

        foreach (var index in UsedClues)
        {
            clues.Remove(index);
        }

        int nextClue = clues[Random.Range(0, clues.Count)];
        UsedClues.Add(nextClue);
        Statics.PlayerPrefsStrings.UsedCluesList = UsedClues;
         
        return nextClue;
    }

    public char GetLetter()
    {
        return RemainingLetters[Random.Range(0, RemainingLetters.Count)];
    }
}
