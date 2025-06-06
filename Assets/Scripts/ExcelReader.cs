using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExcelReader : MonoBehaviour
{
    public string csv = "Database";
    public List<string> Answers = new List<string>(), Questions = new List<string>();
    public Button questionButton;
    public TextMeshProUGUI answerText;

    public Button exitButton;
    public GameObject uiPanel;

    // Referencias para controlar el jugador y cámaras
    public PlayerMover playerMoverScript;
    public GameObject joystickUI;
    public Camera playerCamera;
    public Camera npcCamera;

    void Start()
    {
        TextAsset text = Resources.Load<TextAsset>(csv);
        if (text != null)
        {
            ReadCSV(text.text);
            answerText.text = "";
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(HideUIPanel);
        }
    }

    private void ReadCSV(string csvText)
    {
        string[] rows = csvText.Split('\n');
        for (int i = 0; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(',');
            if(cells.Length < 2) continue;
            Questions.Add(cells[0]);
            Answers.Add(cells[1]);
            Button newQButton = Instantiate(questionButton, questionButton.transform.parent);
            newQButton.GetComponentInChildren<TextMeshProUGUI>().text = cells[0];
            int currentIndex = i;
            newQButton.onClick.AddListener(() => AnswerTheQuestion(currentIndex));
        }
        questionButton.gameObject.SetActive(false);
    }

    public void AnswerTheQuestion(int i)
    {
        answerText.text = Answers[i];
    }

    // Método para activar UI diálogo y bloquear jugador, activar cámara NPC
    public void ShowUIPanel()
    {
        if (uiPanel != null)
            uiPanel.SetActive(true);

        if (playerMoverScript != null)
            playerMoverScript.canMove = false;

        if (joystickUI != null)
            joystickUI.SetActive(false);

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(false);

        if (npcCamera != null)
            npcCamera.gameObject.SetActive(true);
    }

    // Método para cerrar diálogo, activar movimiento, cámara jugador y joystick
    public void HideUIPanel()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);

        if (playerMoverScript != null)
            playerMoverScript.canMove = true;

        if (joystickUI != null)
            joystickUI.SetActive(true);

        if (npcCamera != null)
            npcCamera.gameObject.SetActive(false);

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(true);
    }
}
