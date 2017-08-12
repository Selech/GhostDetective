using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ClueCanvasController : MonoBehaviour
{
    public ClueScriptableObject ClueList;
    public LevelController levelController;
    public GameObject ClueMenuBtn;
    public GameObject ClueIntro;
    public ClueNoteObject ClueNote1;
    public ClueNoteObject ClueNote2;
    private ClueNoteObject activeClueNote;

    public Text GetLetterText;
    public PlayableDirector GetLetterPlayable;
    private bool animationPlaying;
    public Text UnlockedLettersText;

    public void CompletePuzzle()
    {
        // Playable cutscene like ting, kommer..!
        GetLetterPlayable.gameObject.SetActive(true);
        var letter = levelController.GetLetter();
        GetLetterText.text = letter + "";

        GetLetterPlayable.Play();
        GetNewClue();
        UnlockedLettersText.text += letter;
        gameObject.SetActive(false);
        //        GetNewClue();
    }

    public void GetNewClue()
    {
        var ranClue = ClueList.List[levelController.RandomClue(ClueList.List.Count)];
        Statics.PlayerPrefsStrings.UnlockedHintsString = 1;

        GameObject.Find(ranClue.CorrespondingObjectName).GetComponent<InteractableObject>().Activate();

        var ranClueNote = UnityEngine.Random.Range(0, 2);
        activeClueNote = ranClueNote == 0 ? ClueNote1 : ClueNote2;
        activeClueNote.SetClue(ranClueNote == 0, ranClue);
        activeClueNote.ClueNoteGameObject.GetComponent<Button>().onClick.AddListener(CloseClue);
        OpenClue();
    }

    public void CloseClue()
    {
        activeClueNote.Hide();
        ClueMenuBtn.SetActive(true);
    }

    public void OpenClue()
    {
        activeClueNote.Show();
        ClueMenuBtn.SetActive(false);
    }
}

[Serializable]
public class ClueNoteObject
{
    public GameObject ClueNoteGameObject;
    public Text ClueNoteTitle;
    public Text ClueNoteText;
    private Clue currentClue;

    public void SetClue(bool active, Clue clue)
    {
        currentClue = clue;
        ClueNoteTitle.text = currentClue.ClueTitle;
        ClueNoteText.text = GetUnlockedHints();
    }

    public string GetUnlockedHints()
    {
        int unlockedHints = Statics.PlayerPrefsStrings.UnlockedHintsString;

        switch (unlockedHints)
        {
            case 1:
                return currentClue.ClueTextHint1;

            case 2:
                return currentClue.ClueTextHint1 + "\n" + currentClue.ClueTextHint2;

            case 3:
                return currentClue.ClueTextHint1 + "\n" + currentClue.ClueTextHint2 + "\n" + currentClue.ClueTextHint3;

            default:
                return "";
        }
    }

    public void Hide()
    {
        ClueNoteGameObject.SetActive(false);
    }

    public void Show()
    {
        ClueNoteGameObject.SetActive(true);
    }
}