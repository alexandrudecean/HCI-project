using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlanetQuiz
{
    public string question;
    public bool correctAnswer; // true pentru "adevărat", false pentru "fals"
}

[CreateAssetMenu(fileName = "PlanetQuizData", menuName = "Quiz/PlanetQuizData")]
public class PlanetQuizData : ScriptableObject
{
    public List<PlanetQuiz> questions;
    public string planetInfo;
}
