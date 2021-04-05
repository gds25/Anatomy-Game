﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : EventTrigger
{
    public GameObject btnCorrect;

    private bool isDragging;
    private Vector3 origin;

    public void Start() {
        origin = this.transform.position;
        //btnCorrect = GameObject.Find("LungsNext");
       // Debug.Log(btnCorrect.name);
    }

    public void Update() {
        if (isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
       // else
            ////if (transform.position = )
    }

    public override void OnPointerDown(PointerEventData eventData) {
        isDragging = true;
        Debug.Log(this.name);
        if (this.name == "imgHeart") {
            btnCorrect = GameObject.Find("HeartNext");
        } 
        else if (this.name == "imgLungs")
        {
            btnCorrect = GameObject.Find("LungsNext");
        }
        else if (this.name == "imgBrain")
        {
            btnCorrect = GameObject.Find("BrainNext");
        }
        else if (this.name == "imgLiver")
        {
            btnCorrect = GameObject.Find("LiverNext");
        }
        else if (this.name == "imgKidneys")
        {
            btnCorrect = GameObject.Find("KidneysNext");
        }
    }

    public override void OnPointerUp(PointerEventData eventData) {
        isDragging = false;
        if (Mathf.Abs(this.transform.position.x - btnCorrect.transform.position.x) <= 15f &&
            Mathf.Abs(this.transform.position.y - btnCorrect.transform.position.y) <= 15f)
        {
            transform.position = new Vector2(btnCorrect.transform.position.x, btnCorrect.transform.position.y);
            Destroy(this);
            btnCorrect.SetActive(false);
           // UILevelOne.NextPage();
        }
        else transform.position = origin;
    }
}

