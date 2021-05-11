using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class UITutorial : MonoBehaviour
{
    public GameObject imgDragSquare;
    public GameObject imgSquare;
    public GameObject imgCircle;
    public GameObject imgTriangle;
    public GameObject imgHead;
    public GameObject imgBody;
    public GameObject imgHeadOutline;

    public GameObject tempNext;

    private Vector3 origin, ans1, ans2, ans3, ans4;

    public TMP_Text txtQuestion;
    public TMP_Text txtEnd;
    public TMP_Text txtMid;

    public GameObject btnRight;
    public GameObject btnWrong1;
    public GameObject btnWrong2;
    public GameObject btnWrong3;

    public GameObject btnHome;
    public GameObject btnBack;
    public GameObject btnNext;

    private int quizQuestion = 0;

    List<string> questions = new List<string>()
        {
            " Simple, right? Here's something even simpler:\n What shape is this?",
            " Which body part is this?:",
            ""
        };

    List<string> rightAnswers = new List<string>()
        {
            " Square",
            " Head",
            ""
        };

    List<string> wrongAnswers1 = new List<string>()
        {
            " Circle",
            " Shoulder",
            ""
        };

    List<string> wrongAnswers2 = new List<string>()
        {
            " Triangle",
            " Knee",
            ""
        };

    List<string> wrongAnswers3 = new List<string>()
        {
            " Octogan",
            " Toe",
            ""
        };

    int tutPage = 0;

    // Start is called before the first frame update
    private void Start()
    {
        ans1 = btnRight.transform.position;
        ans2 = btnWrong1.transform.position;
        ans3 = btnWrong2.transform.position;
        ans4 = btnWrong3.transform.position;
        origin = imgDragSquare.transform.position;
        Debug.Log("tutorial " + origin);
        
        UpdatePage(tutPage);
        Debug.Log(tempNext.name);
    }

    public void NextPage()
    {
        tutPage++;
        UpdatePage(tutPage);
    }

    public void BackPage()
    {
        tutPage--;
        UpdatePage(tutPage);
    }

    void QuizTime(bool isQuiz)
    {
        if (isQuiz == true)
        {
            txtMid.text = "";

            txtQuestion.text = questions[quizQuestion];
            btnRight.GetComponentInChildren<TMP_Text>().text = rightAnswers[quizQuestion];
            btnWrong1.GetComponentInChildren<TMP_Text>().text = wrongAnswers1[quizQuestion];
            btnWrong2.GetComponentInChildren<TMP_Text>().text = wrongAnswers2[quizQuestion];
            btnWrong3.GetComponentInChildren<TMP_Text>().text = wrongAnswers3[quizQuestion];

            quizQuestion++;
        }
        else
        {
            txtQuestion.text = "";
        }
        btnRight.SetActive(isQuiz);
        btnWrong1.SetActive(isQuiz);
        btnWrong2.SetActive(isQuiz);
        btnWrong3.SetActive(isQuiz);

    }

    void ChangeOrder(GameObject num1, GameObject num2, GameObject num3, GameObject num4)
    {
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
                txtMid.text = "What's inside our bodies? In this game, you'll find out!\n\nClick next to learn how to play.";
                btnBack.SetActive(false);
                btnNext.SetActive(true);
                break;
            case 1:
                txtQuestion.text = "You're going to be drag and dropping a lot. Let's start off with a sample problem:\nDrag and drop the shape into the correct hole.";
                txtMid.text = "";
                imgDragSquare.SetActive(true);
                imgHead.transform.position = new Vector3(-1000, -1000, 0);
                btnNext.SetActive(false);
                btnBack.SetActive(true);
                imgDragSquare.transform.position = origin;
                imgDragSquare.SetActive(true);

                imgSquare.SetActive(true);
                imgCircle.SetActive(true);
                imgTriangle.SetActive(true);
                tempNext = GameObject.Find("Square");
                break;
            case 2:
                QuizTime(true);
                ChangeOrder(btnWrong2, btnWrong3, btnRight, btnWrong1);
                imgCircle.SetActive(false);
                imgTriangle.SetActive(false);
                break;
            case 3:
                QuizTime(false);
                tempNext = GameObject.Find("Question (TMP)");

                txtMid.text = "And there you go!\nEvery time you complete a match, you will have to answer a multiple choice question.\n\nYou now have all the tools necessary to play this game. But let's do another example just in case.";
                btnNext.SetActive(true);

                imgDragSquare.SetActive(false);
                imgSquare.SetActive(false);
                break;
            case 4:
                txtQuestion.text = "Where should this body part go? Drag it onto the correct spot.";

                txtMid.text = "";
                imgHead.transform.position = origin;
                imgHead.SetActive(true);
                imgHeadOutline.SetActive(true);
                imgBody.SetActive(true);
                tempNext = GameObject.Find("HeadOutline");

                btnNext.SetActive(false);
                break;
            case 5:
                ChangeOrder(btnWrong2, btnWrong3, btnWrong1, btnRight);
                QuizTime(true);
                break;
            case 6:
                txtMid.text = "\n\n\nYou are now done with the tutorial.\nAre you ready to start the game?";
                txtEnd.text = "Level 1";
                QuizTime(false);

                btnNext.SetActive(true);

                imgHead.SetActive(false);
                imgBody.SetActive(false);
                imgHeadOutline.SetActive(false);
              
                btnBack.SetActive(false);

                break;
            case 7:
                SceneManager.LoadScene("03Level01Scene");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tempNext.activeSelf == false && btnRight.activeSelf == false && btnNext.activeSelf == false)
        {
            NextPage();
        }
    }
}
