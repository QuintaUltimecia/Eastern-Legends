using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class PlayerPrefsController : EditorWindow
{
    [MenuItem("Game Design/Clear Saves")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

        Debug.Log("Saves is clear.");
    }
}
#endif