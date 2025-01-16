using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetQuizData quizData;
    [SerializeField] private GameObject sun;
    [SerializeField] private float distance;
    [SerializeField] private float speed = 1;

    private void Start()
    {
        transform.position = (transform.position - sun.transform.position).normalized * distance + sun.transform.position;
        transform.position = new Vector3(transform.position.x, sun.transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (sun != null)
        {
            transform.RotateAround(sun.transform.position, Vector3.up, 5 * Time.deltaTime * speed);
        }
    }
}
