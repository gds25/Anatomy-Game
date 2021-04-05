using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Title Scene", order = 0)]
    [Space(2f)]
    [Header("Intro Scene", order = 1)]
    public GameObject imgIntro;
    public GameObject btnBack;
    public GameObject btnNext;
    public TMP_Text txtIntro;
    [Space(2f)]
    [Header("Tutorial Scene", order = 2)]
    [Space(2f)]
    [Header("Level Scene", order = 3)]

    
    int introPage = 0;
    Scene currentScene;

    // Start is called before the first frame update
    private void Start()
    {
      //  Debug.Log();
    }

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    private void Awake()
    {
        //Debug.Log("change");
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "01IntroScene")
        {
            //Debug.Log("intro");
            initIntro();
        }
    }

    public void IntroNext()
    {
        introPage++;
        UpdateIntro(introPage);
    }

    public void IntroBack()
    {
        introPage--;
        UpdateIntro(introPage);
    }

    void initIntro()
    {
        txtIntro.fontSize = 36;
        txtIntro.horizontalAlignment = HorizontalAlignmentOptions.Center;
        txtIntro.text = "What's inside our bodies?\n\nLearn about the body’s major organs and their functions.";
        imgIntro.SetActive(true);
        btnBack.SetActive(false);
    }

    void UpdateIntro(int page)
    {
        switch (page)
        {
            case 0:
                initIntro();
                break;
            case 1:
                txtIntro.fontSize = 22;
                txtIntro.horizontalAlignment = HorizontalAlignmentOptions.Left;
                txtIntro.text = "Overview\n\n" + "Title: What’s Inside our Bodies?\n" +
                "Platform: WebGL build Subject: Biology\n" + 
                "Sub Subject: Human anatomy\n" +
                "Main Focus: Learning about the body’s major organs and their functions.\n" +
                "Learning Level: Grades 3-6\n";
                imgIntro.SetActive(false);
                btnBack.SetActive(true);
                break;
            case 2:
                txtIntro.text = "Proposed Educational Software Solution\n" +
                "\nMany young students find it difficult learning out of a textbook, instead preferring to learn through visual stimulation. Therefore, I propose to develop an interactive simulation where students interact with a virtual model of the human body." +
                "\nI intend to have users drag and drop different organs and match them with their corresponding silhouettes on the human model. I wish to build two different types of textures for these organs: one set of models with realistic colors and another with bright images. I plan to have the user select their preferred texture model to play with, whether it be the realistic version or the bright, color-coded one (if this is too complicated, I plan to just keep the color-coded textures)." +
                "\nAfter each match I plan to trigger a popup with a relevant quiz question regarding the organ that the user must answer. Following this question, I plan to provide supplementary definitions/information to visually connect the information to the respective organ. At the end of the level, I plan to have an (optional) small quiz using the information from those pop-ups, testing how well the user retained the information given to them on that level. The user may wish to skip that quiz or use it to test what they know." +
                "\nIn Level 1, I intend to focus on only the most vital organs: brain, heart, lungs, liver, and kidneys.";
                break;
            case 3:
                txtIntro.text = " Competing Software Review\n" +
                "\n•	Funbrain: The Human Body\nWeb browser game that allows the user to interact with the different systems within the human body in order to see how they function, including the skeletal, respiratory, cardiovascular, and muscular systems. Allows the user to match different names with the respective body part in order to visualize where these parts would be within the body." +
                "\n•	Scholastic StudyJams\nSlideshow with pictures and videos describing the functions of the different organ systems within the body." +
                "\n•	Siemens: Inside the Human Body\nInteractive slideshow with pictures and videos describing the functions of the major organs within the body. Slideshow concludes with two browser games; one allowing the user to “build a skeleton” by dragging and dropping different bones onto the model of a human body, and a small interactive quiz on energy and food.";
                break;
            case 4:
                txtIntro.text = "Competing Software Suggested Improvements\n\n" +
                "•	Gameplay and immersion – Instead of teaching predominantly through slideshows and text, create a human model that the user can interact with, to learn visually." +
                "\n•	Engagement factors - More interactive ways to engage with the information, such as dragging and dropping, matching, and interactive popups and quizzes." +
                "\n•	Better accessibility – Many of these type of web games require the no longer supported Flash player to run. Users should be able to run the applications on both mobile and desktop devices to get the most out of their learning.";
                break;
            case 5:
                txtIntro.text = "Stakeholders and Users\n" +
                "\nTeachers" +
                "\nParents" +
                "\nStudents: 9-13 year old elementary school students";
                break;
            case 6:
                txtIntro.text = "Persona\n" +
                "\nName: Julia" +
                "\nAnge: 12" +
                "\nGender: Female" +
                "\nLocation: Lower-middle class urban USA" +
                "\nPersonal Notes:" +
                "\n•	Loves to help others" +
                "\n•	Enjoys playing with animals at the shelter" +
                "\n•	Has dreams of becoming a doctor" +
                "\nStudent Notes:" +
                "\n•	Dyslexic; struggles with textbook learning" +
                "\n•	Is hyperactive; struggles to stop and analyze" +
                "\n•	Can get easily discouraged" +
                "\n•	Learns best through visualization and simulation";
                break;
            case 7:
                txtIntro.text = "Justification of Persona Decisions\n" +
                "\nJulia represents the users that would most benefit from this application: an elementary school student that needs kinesthetic simulation to properly understand material unfamiliar to them. In Julia, we have a user that wishes to learn more about the topic at hand but has trouble learning through traditional methods. This application will be used to stimulate the learning of students like her.";
                break;
            case 8:
                txtIntro.text = "Problem Scenario\n" +
                "\nJulia has great admiration for her aunt, who recently graduated medical school to become a surgeon. She loves to help others and decides that she one day wants to follow in her aunt’s footsteps and become a doctor. Julia’s fourth grade teacher had recently begun covering human anatomy in science class, but due to budget cuts, her school has no human models in classrooms to analyze. Therefore, her teacher has to teach this material with only an outdated textbook as a guide. Julia, however, is dyslexic, and confuses herself trying to connect the different scientific terms she reads in her books together, without a model to guide her. As a result, she does poorly on her first anatomy quiz. Discouraged by her lack of information retention and her struggling grade in her science class, she begins to question the future career path that she chose for herself.";
                break;
            case 9:
                txtIntro.text = "Activity Scenario\n" +
                "\nThe week after the quiz, Julia’s teacher announces that they will be looking at human models through an interactive computer application, in which the teacher runs on her computer and projects to the board for the class to see. During recess, Julia asked her teacher for a link to the online application, and that afternoon went to the library and used the public computers there to study for her quiz next week. The application immediately helped Julia better visualize the human body and link different organs to their corresponding organ system and its main functions. After using the application for a week, Julia can better visualize what she is learning and now connects the different terms that she learned previously to a proportional human model. This increases her memory retention and overall understanding of the different organ systems. She aces her next quiz, which reignites the ambition she previously had about becoming a doctor. This causes her to search her local library as well as the internet to supplement what she has learned in class.";
                btnNext.SetActive(true);
                break;
            case 10:
                txtIntro.text = "Problem Statement\n" +
                "\nJulia loves to help others and wishes to be a doctor someday, but the amount of information she must learn about the human body overwhelms her. She needs a model to visualize what she is learning lest she gets confused and begins to fall behind in science class. A more interactive type of learning, compared to how she learns at school, would allow her to connect the dots and develop her understanding of the human body and its organ systems.";
                btnNext.SetActive(false);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
