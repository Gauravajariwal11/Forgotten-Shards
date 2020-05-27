using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    private QuestData[] allQuestData;

    public int riddleIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();
        GenerateRiddleIndex();
        SceneManager.LoadScene("Riddle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public QuestData GetCurrentQuestData()
    {
    //    // If we wanted to return different rounds, we could do that here
    //    // We could store an int representing the current round index in PlayerProgress

        return allQuestData[0];
    }

    private void LoadGameData()
    {
        TextAsset file = Resources.Load("Riddles") as TextAsset;

        try
        {

        string dataAsJson = file.ToString();
        GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
        allQuestData = loadedData.allQuestData;
        }

        catch
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    private void GenerateRiddleIndex()
    {
        riddleIndex = Random.Range(0, allQuestData[0].riddles.Length);
    }
}
