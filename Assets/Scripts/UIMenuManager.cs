using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text highscoreText;
    public TMP_InputField inputName;
    

    void Start()
    {
       DataManager.Instance.LoadData();
       StartMenu();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InsertName()
    {
        DataManager.Instance.playerName = inputName.text;
        
        if (DataManager.Instance.playerName.Length != 0)
        {
            DataManager.Instance.nameChanged = true;
            Debug.Log("Username " + DataManager.Instance.playerName + " entered the game");
        }
        
    }

    public void StartMenu()
    {
        if ((DataManager.Instance.playerName != "Anonymous") && DataManager.Instance.highscore != 0)
        {
            highscoreText.text = "Highscore : " + DataManager.Instance.highscore + " (" + DataManager.Instance.playerName + ")";
        } else if ((DataManager.Instance.playerName == "Anonymous") && DataManager.Instance.highscore != 0)
        {
            highscoreText.text = "Highscore : " + DataManager.Instance.highscore + " (" + DataManager.Instance.playerName + ")";
        }
        
    }

    public void SetCurrentHighscore()
    {
        highscoreText.text = "Highscore : " + DataManager.Instance.highscore + " (" + DataManager.Instance.playerName + ")";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
