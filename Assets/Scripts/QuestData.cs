using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public string name;
    public int timeUsedInSeconds;
    public int pointsAddedForCorrectAnswer;
    public int lives;
    public int num_hints;
    public RiddleData[] riddles;
}
