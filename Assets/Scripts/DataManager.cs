using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string bestPlayerName;
    public string playerName;
    public int maxScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]

    class SaveData
    {
        public int maxScore;
        public string bestPlayerName;
    }

    public void SaveScore(int maxScore, string playerName)
    {
        SaveData data = new SaveData();
        data.maxScore = maxScore;
        data.bestPlayerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            maxScore = data.maxScore;
        }
        else
        {
            bestPlayerName = "";
            maxScore = 0;
        }
    }
}
