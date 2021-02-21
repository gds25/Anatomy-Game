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
    public GameObject  btnNext;
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
        txtIntro.text = "placeholder1";
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
                txtIntro.text = "placeholder2";
                imgIntro.SetActive(false);
                btnBack.SetActive(true);
                break;
            case 2:
                txtIntro.text = "placeholder3";
                break;
            case 3:
                txtIntro.text = "placeholder4";
                break;
            case 4:
                txtIntro.text = "placeholder5";
                break;
            case 5:
                txtIntro.text = "placeholder6";
                break;
            case 6:
                txtIntro.text = "placeholder7";
                break;
            case 7:
                txtIntro.text = "placeholder8";
                break;
            case 8:
                txtIntro.text = "placeholder9";
                break;
            case 9:
                txtIntro.text = "placeholder10";
                btnNext.SetActive(true);
                break;
            case 10:
                txtIntro.text = "placeholder11";
                btnNext.SetActive(false);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
