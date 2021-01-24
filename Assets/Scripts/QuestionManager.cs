using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Player m_Player;

    public QuestionSet Questions;

    private Question m_CurrentQuestion;
    private bool m_HasAnswered = false;
    private int m_Answer;
    private int m_AnsweredButtonIndex;

    public QuestionText m_QuestionText;
    public AnswerButton[] m_AnswerButtons = new AnswerButton[5];
    public GameObject m_QuestionsUI;

    public void RandomizeQuestion()
    {
        m_CurrentQuestion = Questions.GetRandomQuestion().GetComponent<Question>();
        for (int i = 0; i < m_AnswerButtons.Length; i++)
            m_AnswerButtons[i].SetQuestion(m_CurrentQuestion, i);
        m_QuestionText.SetText(m_CurrentQuestion.GetQuestionText());

        Debug.Log(m_CurrentQuestion.GetQuestionText());
    }

    public void OnAnswer(int buttonIndex)
    {
        if (!m_HasAnswered)
        {
            m_HasAnswered = true;
            m_Answer = buttonIndex;
            m_AnsweredButtonIndex = buttonIndex;
            for (int i = 0; i < m_AnswerButtons.Length; i++)
                m_AnswerButtons[i].Disable();
            Debug.Log("Response: " + m_Answer);
        }
    }

    public void ValidateAnswer()
    {
        if(m_CurrentQuestion.GetCorrectAnswerIndex() == m_Answer)
        {
            Debug.Log("Answer correct!");
            m_AnswerButtons[m_AnsweredButtonIndex].SetCorrect();
            m_Player.AddScore(5);
        }
        else
        {
            Debug.Log("Answer incorrect!");
            m_AnswerButtons[m_AnsweredButtonIndex].SetWrong();
            m_AnswerButtons[m_CurrentQuestion.GetCorrectAnswerIndex()].SetCorrect();
            m_Player.AddScore(-5);
        }
    }

    public void OnReset()
    {
        m_HasAnswered = false;
        m_AnsweredButtonIndex = -1;
        for (int i = 0; i < m_AnswerButtons.Length; i++)
            m_AnswerButtons[i].Reset();
    }

    public void OnOver()
    {
        m_QuestionsUI.SetActive(false);
    }

    public bool HasAnswered()
    {
        return m_HasAnswered;
    }
}