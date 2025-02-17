using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ExcelReader : MonoBehaviour
{
    public string csv = "Database";
    public List<string> Answers, Questions;
    public Button questionButton;
    public TextMeshProUGUI answerText;

    public Button exitButton;

    public GameObject uiPanel;

    
    
    void Start()
    {
        TextAsset text = Resources.Load<TextAsset>(csv);
        if(csv!= null)
        {
            ReadCSV(text.text);
            answerText.text = "";
        }

        if(exitButton != null)
        {
            exitButton.onClick.AddListener(HideUIPanel);
        }
    }
    private void ReadCSV(string csv)
    {
        string[] rows = csv.Split("\n");
        for (int i=0; i<rows.Length; i++)
        {
            string[] cells = rows[i].Split(",");
            Questions.Add(cells[0]);
            Button newQButton = Instantiate(questionButton, questionButton.transform.parent);
            newQButton.GetComponentInChildren<TextMeshProUGUI>().text = cells[0];
            var currentIndex = i;
            newQButton.onClick.AddListener(() => AnswerTheQuestion(currentIndex));
            /*newQButton.onClick.AddListener(delegate { 
                AnswerTheQuestion(currentIndex);
            } );*/
            Answers.Add(cells[1]);
        }
        questionButton.gameObject.SetActive(false);
    }
    public void AnswerTheQuestion(int i)
    {
        answerText.text = Answers[i];
    }
    public void HideUIPanel()
    {
        if(uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}
