using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Button startButton;
    public TMP_InputField nameField;
    public TMP_Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.Instance.playerName == "")
        {
            startButton.interactable = false;
        } else {
            nameField.text = ScoreManager.Instance.playerName;
        }
        bestScoreText.text = "Best Score: " + ScoreManager.Instance.BestScorer + " : " + ScoreManager.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if (ScoreManager.Instance.playerName != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveBestScore();

#if UNITY_EDITOR         
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void UpdateName()
    {
        Debug.Log("Name updated to: " + nameField.text);
        ScoreManager.Instance.playerName = nameField.text;
        if (ScoreManager.Instance.playerName == "")
        {
            startButton.interactable = false;
        } else
        {
            startButton.interactable = true;
        }
    }
}
