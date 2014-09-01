using UnityEngine;
using System.Collections;

public class BallSensor : MonoBehaviour
{
    public int sensorValue = 0;
    public GUIText scoreReference;
    public GameObject alertReference;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Camera.main.GetComponent<ThrowBall>().ballOnStage = false;
        scoreReference.text = (int.Parse(scoreReference.text) + sensorValue).ToString();

        Camera.main.GetComponent<ThrowBall>().ballsLeft--;
        Camera.main.GetComponent<ThrowBall>().ballsTextReference.text = Camera.main.GetComponent<ThrowBall>().ballsLeft.ToString();

        if (Camera.main.GetComponent<ThrowBall>().ballsLeft == 0)
        {
            Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
            Invoke("Reload", 3);
        }
    }

    void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}