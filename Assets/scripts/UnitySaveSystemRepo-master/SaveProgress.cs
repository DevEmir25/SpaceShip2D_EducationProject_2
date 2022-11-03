using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public static SaveProgress instance;
    public PlayerData playerData = new PlayerData();
    private void Awake()
    {
        instance = this;
        SaveSystem.LoadPlayer();
    }
}