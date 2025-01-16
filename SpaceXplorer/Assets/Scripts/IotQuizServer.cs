using System;
using System.Net;
using System.Text;
using UnityEngine;

public class IoTQuizServer : MonoBehaviour
{
    private HttpListener httpListener;
    public QuizManager quizManager; // Legăm QuizManager pentru a răspunde la întrebări

    void Start()
    {
        httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://*:8080/quiz/"); // Ascultă pe portul 8080
        httpListener.Start();
        Debug.Log("Server HTTP pornit pe portul 8080");

        // Rulează ascultarea pe un fir separat
        httpListener.BeginGetContext(OnRequestReceived, null);
    }

    private void OnRequestReceived(IAsyncResult result)
    {
        if (!httpListener.IsListening) return;

        var context = httpListener.EndGetContext(result);
        var request = context.Request;

        // Citește payload-ul trimis
        string body;
        using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
        {
            body = reader.ReadToEnd();
        }

        Debug.Log("Mesaj primit: " + body);

        // Parsează răspunsul trimis
        if (body.Contains("\"response\": \"1\""))
        {
            quizManager.AnswerQuestion(true); // Trimite răspunsul True
        }
        else if (body.Contains("\"response\": \"2\""))
        {
            quizManager.AnswerQuestion(false); // Trimite răspunsul False
        }

        // Răspunde la client
        var response = context.Response;
        string responseString = "{\"status\": \"success\"}";
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
        response.OutputStream.Close();

        // Continuă să asculte
        httpListener.BeginGetContext(OnRequestReceived, null);
    }

    void OnApplicationQuit()
    {
        if (httpListener != null && httpListener.IsListening)
        {
            httpListener.Close();
            Debug.Log("Server HTTP oprit.");
        }
    }
}
