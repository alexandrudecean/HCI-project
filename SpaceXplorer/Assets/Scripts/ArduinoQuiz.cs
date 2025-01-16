using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoQuiz : MonoBehaviour
{
    SerialPort serialPort;
    public QuizManager quizManager;

    void Start()
    {
        // Deschide portul doar dacă platforma este Android sau Windows
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            serialPort = new SerialPort("COM3", 9600); // Setează portul corect
            try
            {
                serialPort.Open();
                serialPort.ReadTimeout = 1;
                Debug.Log("Port serial deschis cu succes!");
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
                if (input == "1") // Butonul pentru "adevărat"
                {
                    quizManager.AnswerQuestion(true);
                }
                else if (input == "2") // Butonul pentru "fals"
                {
                    quizManager.AnswerQuestion(false);
                }
            }
            catch (System.TimeoutException) { } // Prinde timeout-ul și continuă
            catch (System.Exception e)
            {
                Debug.LogError("Eroare la citirea portului: " + e.Message);
            }
        }

        // Testare în Unity Editor cu tastele 1 și 2
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quizManager.AnswerQuestion(true);
                Debug.Log("Testare Editor: Adevărat");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quizManager.AnswerQuestion(false);
                Debug.Log("Testare Editor: Fals");
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Port serial închis corect.");
        }
    }
}
