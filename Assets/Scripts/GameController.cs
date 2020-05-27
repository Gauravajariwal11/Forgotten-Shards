using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public Text riddleText;
    public Text userAnswer;
    public Text timeUsedDisplay;
    public Text numHintDisplay;
    public Text hintDisplay;
    public Text livesDisplay;
    public GameObject hintPanel;

    private DataController dataController;
    private QuestData currentQuestData;
    private RiddleData[] riddlePool;
    private RiddleData riddleData;

    private int playerScore;
    private float timeUsed;
    private bool isQuestActive;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();                              // Store a reference to the DataController so we can request the data we need for this round

        currentQuestData = dataController.GetCurrentQuestData();                            // Ask the DataController for the data for the current round. At the moment, we only have one round - but we could extend this
        riddlePool = currentQuestData.riddles;                                          // Take a copy of the questions so we could shuffle the pool or drop questions from it without affecting the original RoundData object

        timeUsed = currentQuestData.timeUsedInSeconds;                                // Set the time limit for this round based on the RoundData object
        UpdateTimeUsedDisplay();
        UpdateNumHintDisplay();
        UpdateLivesDisplay();
        playerScore = 0;

        ShowQuestion();
        isQuestActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isQuestActive)
        {
            timeUsed += Time.deltaTime;                                                // If the round is active, subtract the time since Update() was last called from timeRemaining
            UpdateTimeUsedDisplay();
        }
    }

    private void ShowQuestion()
    {
        riddleData = riddlePool[dataController.riddleIndex];                                // Get the QuestionData for the current question
        riddleText.text = riddleData.riddleText;                                                            // Update questionText with the correct text
    }

    private void UpdateTimeUsedDisplay()
    {
        timeUsedDisplay.text = "Time: " + Mathf.Round(timeUsed).ToString();
    }

    private bool CheckAnswer()
    {
        int res = string.Compare(riddleData.answer, userAnswer.text.ToLower());
        if(res == 0)
        {
            isQuestActive = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateNumHintDisplay()
    {
        numHintDisplay.text = "Hints: " + currentQuestData.num_hints;
    }

    public void UpdateLivesDisplay()
    {
        livesDisplay.text = "Lives: " + currentQuestData.lives;
    }

    public void UseHint()
    {
        hintPanel.SetActive(true);
        if (currentQuestData.num_hints > 0)
        {
            hintDisplay.text = riddleData.hints[3 - currentQuestData.num_hints];
            currentQuestData.num_hints--;
            UpdateNumHintDisplay();
        }
        else
        {
            hintDisplay.text = "You've used up all your hints for this quest. I can't help you any more...";
        }
        
    }



    public void DoneButtonClicked()
    {
        hintPanel.SetActive(false);
    }

    public void EnterButtonClicked()
    {
        bool res = CheckAnswer();
        if (res)
        {
            SceneManager.LoadScene("win");
            SceneManager.LoadScene("World");
        }
        else
        {
            currentQuestData.lives--;
            SceneManager.LoadScene("loss");
        }
    }

}
