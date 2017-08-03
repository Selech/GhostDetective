using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NetworkWindow : EditorWindow
{
	[MenuItem("Tools/Delete all PlayerPrefs")]
	static void DeletePlayerPrefs()
	{
        PlayerPrefs.DeleteAll();
	}
}
