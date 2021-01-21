using UnityEngine;

public class Question : MonoBehaviour
{
    public GameManager m_GameManager;

    private bool m_HasBeenUsed = false;

    public string m_QuestionText;
    public string[] m_Answers = new string[5];

    public int m_CorrectAnswer;

    public bool IsAnswerCorrect(int index)
    {
        return m_CorrectAnswer == index;
    }

    public string GetAnswerText(int index)
    {
        return m_Answers[index];
    }

    public string GetCorrectAnswerText()
    {
        return m_Answers[m_CorrectAnswer];
    }

    public int GetCorrectAnswerIndex()
    {
        return m_CorrectAnswer;
    }

    public string GetQuestionText()
    {
        return m_QuestionText;
    }

    public void OnUsed()
    {
        m_HasBeenUsed = true;
    }

    public bool HasBeenUsed()
    {
        return m_HasBeenUsed;
    }
}
