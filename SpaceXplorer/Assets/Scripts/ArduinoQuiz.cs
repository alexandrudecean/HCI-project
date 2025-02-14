﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoQuiz : MonoBehaviour
{
    SerialPort serialPort;
    public QuizManager quizManager;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            serialPort = new SerialPort("COM3", 9600);
            try
            {
                serialPort.Open();
                serialPort.ReadTimeout = 1;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Eroare la deschiderea portului: " + e.Message);
            }
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string input = serialPort.ReadLine();
                if (input == "1")
                {
                    //quizManager.AnswerQuestion(true);
                }
                else if (input == "2")
                {
                    //quizManager.AnswerQuestion(false);
                }
            }
            catch (System.TimeoutException) { }
            catch (System.Exception e)
            {
                Debug.LogError("Eroare la citirea portului: " + e.Message);
            }
        }

        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //quizManager.AnswerQuestion(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //quizManager.AnswerQuestion(false);
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
