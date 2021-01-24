using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionSet : MonoBehaviour
{
    public List<GameObject> Questions = new List<GameObject>();  

    public GameObject GetQuestion(int index)
    {
        return Questions[index];
    }

    public GameObject GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, Questions.Count);
        Debug.Log(Questions.Count);
        GameObject question = Questions[randomIndex];
        Questions.RemoveAt(randomIndex);
        
        return question;
    }
}