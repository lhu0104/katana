using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ConfigurationCreator : MonoBehaviour
{
    [MenuItem("Configuration/Music/Edit")]
    public static void EditMusicConfig()
    {
        var instance = MusicConfiguration.Instance;
        EditorGUIUtility.PingObject(MusicConfiguration.Instance);
        Selection.activeObject = MusicConfiguration.Instance;
        // AssetDatabase.CreateAsset(instance, "Assets/Resources/UserConfiguration.asset");
    }
    [MenuItem("Configuration/Music/Create")]
    public static void CreateMusicConfig()
    {
        var instance = new MusicConfiguration();
        AssetDatabase.CreateAsset(instance, "Assets/Resources/MusicConfiguration.asset");
    }
    
}