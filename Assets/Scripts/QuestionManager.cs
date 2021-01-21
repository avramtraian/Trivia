using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public QuestionSet Questions;

    private Question CurrentQuestion;
    private bool m_HasAnswered = false;
    private int m_Answer;
    private int m_AnsweredButtonIndex;

    public QuestionText m_QuestionText;
    public AnswerButton[] m_AnswerButtons = new AnswerButton[5];

    public void RandomizeQuestion()
    {
        CurrentQuestion = Questions.GetRandomQuestion().GetComponent<Question>();
        for (int i = 0; i < m_AnswerButtons.Length; i++)
            m_AnswerButtons[i].SetQuestion(CurrentQuestion, i);
        m_QuestionText.SetText(CurrentQuestion.GetQuestionText());

        Debug.Log(CurrentQuestion.GetQuestionText());
    }

    public void OnAnswer(int buttonIndex)
    {
        if (!m_HasAnswered)
        {
            m_HasAnswered = true;
            m_Answer = buttonIndex;
            m_AnsweredButtonIndex = buttonIndex;
            m_AnswerButtons[buttonIndex].SetSelectedSprite();
            Debug.Log("Response: " + m_Answer);
        }
    }

    public void ValidateAnswer()
    {
        if(CurrentQuestion.GetCorrectAnswerIndex() == m_Answer)
        {
            Debug.Log("Answer correct!");
            if (m_AnsweredButtonIndex != -1)
                m_AnswerButtons[m_AnsweredButtonIndex].SetAsCorrectAnswer();
        }
        else
        {
            m_AnswerButtons[m_AnsweredButtonIndex].SetAsWrongAnswer();
            m_AnswerButtons[CurrentQuestion.GetCorrectAnswerIndex()].SetCorrectAnswer();
            Debug.Log("Answer incorrect!");
        }
    }

    public void OnReset()
    {
        m_HasAnswered = false;
        m_AnsweredButtonIndex = -1;
        for (int i = 0; i < m_AnswerButtons.Length; i++)
            m_AnswerButtons[i].ResetSprite();
    }

    public bool HasAnswered()
    {
        return m_HasAnswered;
    }
}