using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager Instance;
    public int highscore;
    public string playerName;
    public bool nameChanged = false;

    private void Awake()
    {
        

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveInfo
    {
        public int highscore;
        public string playerName;
    }

    public void SaveData()
    {
        if (NewHighscore())
        {
            SaveInfo data = new SaveInfo();
            data.playerName = DataManager.Instance.playerName;
            data.highscore = DataManager.Instance.highscore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
            Debug.Log(Application.persistentDataPath + "/savedata.json");
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);
            
            DataManager.Instance.highscore = data.highscore;
            DataManager.Instance.playerName = data.playerName;
        }    
    }

    public bool NewHighscore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveInfo data = JsonUtility.FromJson<SaveInfo>(json);

            if (DataManager.Instance.highscore > data.highscore)
            {
                return true;
            } else
            {
                return false;
            }
        }

        return true;
    }

    public SaveInfo GetData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        DataManager.SaveInfo data = new DataManager.SaveInfo();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<DataManager.SaveInfo>(json);
        }

        return data;
    }

}
