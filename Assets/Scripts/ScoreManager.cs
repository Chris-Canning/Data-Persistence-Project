using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public string playerName;
    public int score;

    public int BestScore;
    public string BestScorer;

    public TMP_Text bestScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestScorer;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestScorer = BestScorer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved to: " + Application.persistentDataPath + " " + BestScorer + " : " + BestScore);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScorer = data.BestScorer;
            Debug.Log("Loaded from: " + Application.persistentDataPath + " " + BestScore + " : " + BestScorer);
        }
        else
        {
            Debug.Log("No file to load from: " + Application.persistentDataPath + " " + BestScore + " " + BestScorer);

        }
        bestScoreText.text = "Best Score: " + BestScorer + " : " + BestScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
