using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UILevelOne : MonoBehaviour
{
    public GameObject imgHumanModel;
    public GameObject imgHeart;
    public GameObject imgBrain;
    public GameObject imgLungs;
    public GameObject imgLiver;
    public GameObject imgKidneys;
  //  public GameObject tempOrgan;
    public GameObject tempNext;

    private Vector3 origin, ans1, ans2, ans3, ans4;

    public TMP_Text txtQuestion;
    public TMP_Text txtEnd;

    public GameObject btnRight;
    public GameObject btnWrong1;
    public GameObject btnWrong2;
    public GameObject btnWrong3;

    private int quizQuestion = 0;

    List<string> questions = new List<string>()
        {
            " What organ is this?",
            " The brain could be considered: ",
            " What organ is this?",
            " The heart's main function is to: ",
            " What organ is this?",
            " The lungs primarily: ",
            " What organ is this?",
            " The kidneys help to: ",
            " What organ is this?",
            " One of the liver's main functions is to: "
        };

    List<string> rightAnswers = new List<string>()
        {
            " Brain",
            " the control center of the body.",
            " Heart",
            " pump blood around the body.",
            " Lungs",
            " bring oxygen into your blood.",
            " Kidneys",
            " keep your body clean from waste.",
            " Liver",
            " store fuel for your body."
        };

        List<string> wrongAnswers1 = new List<string>()
        {
            " Heart",
            " the least important part of the body.",
            " Brain",
            " digest food.",
            " Small intestine",
            " remove waste from the body.",
            " Lungs",
            " expand your chest when you breathe.",
            " Bladder",
            " let you know when your body is hungry."
        };

        List<string> wrongAnswers2 = new List<string>()
        {
            " Gallbladder",
            " the most durable organ in your body.",
            " Kidneys",
            " remove waste from the body.",
            " Spleen",
            " store water for later use.",
            " Stomach",
            " keep your body warm.",
            " Arteries",
            " store blood that the heart isn't pumping."
        };

        List<string> wrongAnswers3 = new List<string>()
        {
            " Pituitary gland",
            " the smallest organ in your body.",
            " Liver",
            " control your body's nervous system.",
            " Heart",
            " brings carbon dioxide into your blood.",
            " Cerebellum",
            " store fat that the body saves up.",
            " Brain",
            " help strengthen your muscles."
        };

    int lvlPage = 0;

    // Start is called before the first frame update
    private void Start()
    {
        ans1 = btnRight.transform.position;
        ans2 = btnWrong1.transform.position;
        ans3 = btnWrong2.transform.position;
        ans4 = btnWrong3.transform.position;
        origin = imgHeart.transform.position;
        tempNext = GameObject.Find("BrainNext");
        UpdatePage(lvlPage);
        Debug.Log(tempNext.name);
    }

    public void NextPage()
    {
        lvlPage++;
        UpdatePage(lvlPage);
    }

    public void BackPage()
    {
        lvlPage--;
        UpdatePage(lvlPage);
    }
    
    void initIntro()
    {
        imgHeart.transform.position = new Vector3(-1000,-1000, 0);
        imgLungs.transform.position = new Vector3(-1000, -1000, 0);
        imgLiver.transform.position = new Vector3(-1000, -1000, 0);
        imgKidneys.transform.position = new Vector3(-1000, -1000, 0);

        imgBrain.SetActive(true);
    }

    void QuizTime(bool isQuiz)
    {
        if(isQuiz == true) {
            txtQuestion.text = questions[quizQuestion];
            btnRight.GetComponentInChildren<TMP_Text>().text = rightAnswers[quizQuestion];
            btnWrong1.GetComponentInChildren<TMP_Text>().text = wrongAnswers1[quizQuestion];
            btnWrong2.GetComponentInChildren<TMP_Text>().text = wrongAnswers2[quizQuestion];
            btnWrong3.GetComponentInChildren<TMP_Text>().text = wrongAnswers3[quizQuestion];
           
            quizQuestion++;
        }
        else { 
            txtQuestion.text = "Drag the organ to the right spot on the model.";
        }
        btnRight.SetActive(isQuiz);
        btnWrong1.SetActive(isQuiz);
        btnWrong2.SetActive(isQuiz);
        btnWrong3.SetActive(isQuiz);

    }

    void ChangeOrder(GameObject num1, GameObject num2, GameObject num3, GameObject num4) {
        num1.transform.position = ans1;
        num2.transform.position = ans2;
        num3.transform.position = ans3;
        num4.transform.position = ans4;
    }

    void UpdatePage(int page)
    {
        switch (page)
        {
            case 0:
                QuizTime(false);
                initIntro();
                break;
            case 1:
                QuizTime(true);
                break;
            case 2:
                ChangeOrder(btnWrong2, btnWrong3, btnRight, btnWrong1);
                QuizTime(true);
                break;
            case 3:
                QuizTime(false);
                imgHeart.transform.position = origin;
                imgHeart.SetActive(true);
                tempNext = GameObject.Find("HeartNext");
                break;
            case 4:
                ChangeOrder(btnRight, btnWrong3, btnWrong2, btnWrong1);
                QuizTime(true);
                break;
             case 5:
                ChangeOrder(btnWrong2, btnWrong3, btnWrong1, btnRight);
                QuizTime(true);
                break;
            case 6:
                QuizTime(false);
                imgLungs.transform.position = origin;
                imgLungs.SetActive(true);
                tempNext = GameObject.Find("LungsNext");
                break;
            case 7:
                ChangeOrder(btnWrong2, btnWrong3, btnRight, btnWrong1);
                QuizTime(true);
                break;
            case 8:
                QuizTime(true);
                break;
            case 9:
                QuizTime(false);
                imgKidneys.transform.position = origin;
                imgKidneys.SetActive(true);
                tempNext = GameObject.Find("KidneysNext");
                break;
            case 10:
                ChangeOrder(btnWrong2, btnWrong3, btnWrong1, btnRight);
                QuizTime(true);
                break;
            case 11:
                ChangeOrder(btnWrong2, btnRight, btnWrong3, btnWrong1);
                QuizTime(true);
                break;
            case 12:
                QuizTime(false);
                imgLiver.transform.position = origin;
                imgLiver.SetActive(true);
                tempNext = GameObject.Find("LiverNext");
                break;
            case 13:
                ChangeOrder(btnRight, btnWrong3, btnWrong1, btnWrong2);
                QuizTime(true);
                break;
            case 14:
                ChangeOrder(btnWrong1, btnRight, btnWrong3, btnWrong2);
                QuizTime(true);
                break;
            case 15:
                QuizTime(false);
                txtQuestion.text = "";
                txtEnd.text = "Congratulations! You can now identify some of the major organs in the human body.";
                break;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (tempNext.activeSelf == false && btnRight.activeSelf == false)
        {
            NextPage();
        }
    }
}
