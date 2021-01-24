using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Button m_Button;
    public TextMeshProUGUI m_Text;
    public Image m_Image;
    public RectTransform m_ImageTransform;

    public Sprite m_CorrectSprite;
    public Sprite m_WrongSprite;

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

    public void SetChecked()
    {
            ColorBlock newColors = m_Button.colors;
            newColors.disabledColor = new Color(255, 255, 255, 160);
            m_Button.colors = newColors;
            m_Button.interactable = false;
    }

    public void Reset()
    {
        ColorBlock newColors = m_Button.colors;
        newColors.disabledColor = new Color(255, 255, 255, 0);
        m_Button.colors = newColors;
        m_Button.interactable = true;

        m_ImageTransform.Rotate(new Vector3(0.0f, 0.0f, -m_ImageTransform.eulerAngles.z));
        m_Image.enabled = false;
    }

    public void SetCorrect()
    {
        m_Image.sprite = m_CorrectSprite;
        m_Image.enabled = true;
        m_ImageTransform.Rotate(new Vector3(0.0f, 0.0f, -m_ImageTransform.eulerAngles.z));
    }

    public void SetWrong()
    {
        m_Image.sprite = m_WrongSprite;
        m_Image.enabled = true;
        m_ImageTransform.Rotate(new Vector3(0.0f, 0.0f, -m_ImageTransform.eulerAngles.z + 45.0f));
    }

    public void Disable()
    {
        m_Button.interactable = false;
    }
}