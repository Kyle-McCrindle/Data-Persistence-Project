using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public SaveData saveData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    internal void SaveGame()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savegame.json", json);
    }

    internal void LoadGame()
    {
        string savePath = Application.persistentDataPath + "/savegame.json";
        if (File.Exists(savePath))
        {
            string fileContent = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveData>(fileContent);
        }
        else
        {
            saveData = new SaveData();
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string LatestPlayerName;
        public GameScore HighestScore;
    }

    [System.Serializable]
    public class GameScore
    {
        public string PlayerName;
        public int PlayerScore;
    }
}
