using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuizQuestion {
    public string question;
    public string[] options;
    public string answer;
}

[System.Serializable]
public class QuizData {
    public QuizQuestion[] questions;
}

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] private Button interactButton;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text questionText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private Button option3Button;
    [SerializeField] private Button option4Button;
    private QuizData quizData;
    private int currentQuestionIndex;

    void Start()
    {
        interactButton.onClick.AddListener(OnInteractButtonClicked);
        canvas.SetActive(false);
    }

    private void OnInteractButtonClicked()
{
    currentQuestionIndex = Random.Range(0, quizData.questions.Length);
    questionText.text = quizData.questions[currentQuestionIndex].question;

    // Set the text of the option buttons
    option1Button.GetComponentInChildren<Text>().text = quizData.questions[currentQuestionIndex].options[0];
    option2Button.GetComponentInChildren<Text>().text = quizData.questions[currentQuestionIndex].options[1];
    option3Button.GetComponentInChildren<Text>().text = quizData.questions[currentQuestionIndex].options[2];
    option4Button.GetComponentInChildren<Text>().text = quizData.questions[currentQuestionIndex].options[3];

    canvas.SetActive(true);
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AccessButton"))
        {
            string jsonString = System.IO.File.ReadAllText(Application.dataPath + "/Data/questions.json");
            Debug.Log("JSON string: " + jsonString);
            quizData = JsonUtility.FromJson<QuizData>(jsonString);
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("AccessButton"))
        {
            canvas.SetActive(false);
        }
    }
}
