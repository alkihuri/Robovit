﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSlogToGuessController : MonoBehaviour
{
    public bool isGuessed = false;
    public string text;
    // Start is called before the first frame update

    public void SetText(string i)
    {
        text = i;
        /*if (DataStorage.level < (int)Level.High)
            GetComponentInChildren<Text>().text = i;
        else*/
        GetComponentInChildren<Text>().text = "*";
    }

    internal object ToList()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGuessed)
        {
            GetComponentInChildren<Text>().text = text;
            GetComponentInChildren<Text>().color = Color.green;
        }
    }
}