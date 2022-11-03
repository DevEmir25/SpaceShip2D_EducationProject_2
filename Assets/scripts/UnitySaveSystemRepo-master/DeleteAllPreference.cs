#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class DeleteAllPreference : EditorWindow
{
    [MenuItem("Tools/Delete All Data")]
    public static void DeleteData()
    {
        Debug.Log("Bellek temizlendi");
        SaveSystem.DeleteData();
        PlayerPrefs.DeleteAll();

    }

    
    public static void ShowWindow()
    {
        GetWindow<DeleteAllPreference>("Delete All Data");
    }
    //void OnGUI()
    //{
    //    GUILayout.Label("Delete Memory", EditorStyles.boldLabel);
    //    if(GUILayout.Button("DeleteAllPreference"))
    //    {
    //        _DeleteAllPreference();
    //    }
    //}
    //void _DeleteAllPreference()
    //{
    //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    cube.transform.position = new Vector3(0,0,0);
    //}
}

#endif
