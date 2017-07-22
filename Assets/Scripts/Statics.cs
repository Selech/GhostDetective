using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics
{
    public class PlayerPrefsStrings
    {
        public static List<int> UsedCluesList
        {
            get
            {
                List<int> usedClues = new List<int>();
                string usedCluesString = PlayerPrefs.GetString("UsedClueString");
                if (usedCluesString == "")
                    return usedClues;

                foreach (var clueNumber in usedCluesString.Split('|'))
                {
                    usedClues.Add(int.Parse(clueNumber));
                }

                return usedClues;
            }

            set
            {
                var split = "";
                var combinedString = "";
                foreach (var clueNumber in value)
                {
                    combinedString += split + clueNumber;
                    split = "|";
                }

                PlayerPrefs.SetString("UsedClueString", combinedString);
            }
        }

        public static int UnlockedHintsString
        {
            get
            {
                return PlayerPrefs.GetInt("UnlockedHints");
            }

            set
            {
                PlayerPrefs.SetInt("UnlockedHints", value);
            }
        }

        public static string CurrentName
        {
            get
            {
                return PlayerPrefs.GetString("CurrentName");
            }

            set
            {
                PlayerPrefs.SetString("CurrentName", value);
            }
        }

        public static List<char> UnlockedLetters
        {
            get
            {
                List<char> unlockedLetters = new List<char>();
                foreach (char letter in PlayerPrefs.GetString("UnlockedLetters"))
                {
                    unlockedLetters.Add(letter);
                }

                return unlockedLetters;
            }

            set
            {
                var combinedString = "";
                foreach (var clueNumber in value)
                {
                    combinedString += clueNumber;
                }

                PlayerPrefs.SetString("UnlockedLetters", combinedString);
            }
        }
    }
}