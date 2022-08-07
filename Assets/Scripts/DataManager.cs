using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string heldBy;

    public int highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Load();
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string heldBy;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.heldBy = heldBy;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            heldBy = data.heldBy;
        } else
        {
            highScore = 0;
            heldBy = "Nobody";
        }

    }
}
