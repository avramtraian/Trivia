using UnityEngine;

public class QuestionSet : MonoBehaviour
{
    public GameObject[] Questions = new GameObject[4];

    private int m_GeneratedTimes = 0;

    public GameObject GetQuestion(int index)
    {
        return Questions[index];
    }

    public GameObject GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, Questions.Length);
        GameObject question = Questions[randomIndex];
        
        return question;
    }
}