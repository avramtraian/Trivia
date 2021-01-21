using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    public Sprite m_UnselectedSprite;
    public Sprite m_SelectedSprite;
    public Sprite m_CorrectSelectedSprite;
    public Sprite m_WrongSelectedSprite;
    public Sprite m_CorrectSprite;

    public GameManager m_GameManager;
    private Question m_Question;
    private int m_AnswerIndex;

    public void SetQuestion(Question question, int index)
    {
        m_Question = question;
        m_AnswerIndex = index;
        Refresh();
    }

    private void Refresh()
    {
        m_Text.text = m_Question.GetAnswerText(m_AnswerIndex);
    }

    public void SetSelectedSprite()
    {
        this.GetComponent<Image>().sprite = m_SelectedSprite;
    }

    public void SetAsCorrectAnswer()
    {
        this.GetComponent<Image>().sprite = m_CorrectSelectedSprite;
    }

    public void SetAsWrongAnswer()
    {
        this.GetComponent<Image>().sprite = m_WrongSelectedSprite;
    }

    public void SetCorrectAnswer()
    {
        this.GetComponent<Image>().sprite = m_CorrectSprite;
    }

    public void ResetSprite()
    {
        this.GetComponent<Image>().sprite = m_UnselectedSprite;
    }
}