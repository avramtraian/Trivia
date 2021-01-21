using UnityEngine;
using TMPro;

public class QuestionText : MonoBehaviour
{
    public TextMeshProUGUI m_Text;

    public void SetText(string newText)
    {
        m_Text.text = newText;
    }
}