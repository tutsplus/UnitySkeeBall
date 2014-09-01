using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour
{
    private Vector3 throwSpeed = new Vector3(0, 0, 1100);
	public GameObject ballReference;
	private Vector2 startPos;
	private Vector2 endPos;
	private Vector2 minDistance = new Vector2(0, 100);
	private Vector3 ballPos = new Vector3(0, 0.38f, -11.41f);
    public bool ballOnStage = false;
    public int ballsLeft = 5;
    public GUIText ballsTextReference;
    public AudioClip throwSound;

    void Update()
    {
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began)
			{
				startPos = touch.position;
			}
			if(touch.phase == TouchPhase.Ended)
			{
				endPos = touch.position;
			}

			/* Compare positions */

			if(endPos.y - startPos.y >= minDistance.y && !ballOnStage && ballsLeft > 0)
			{
                /* Divide screen in 3 parts */
				
				/* Left */
				if(touch.position.x >= 0 && touch.position.x <= Screen.width / 3)
				{
					ballPos.x = Random.Range(-0.87f, -0.35f);
				}
				/* Center */
				else if(touch.position.x > Screen.width / 3 && touch.position.x <= (Screen.width / 3) * 2)
				{
					ballPos.x = Random.Range(-0.35f, 0.22f);
				}
				/* Right */
				else if(touch.position.x > (Screen.width / 3) * 2 && touch.position.x <= Screen.width)
				{
					ballPos.x = Random.Range(0.22f, 0.36f);
				}

				GameObject ball = Instantiate(ballReference, ballPos, transform.rotation) as GameObject;
				ball.rigidbody.AddForce(throwSpeed);

                AudioSource.PlayClipAtPoint(throwSound, transform.position);

                endPos = new Vector2(0, 0);
                startPos = new Vector2(0, 0);
                ballOnStage = true;
			}
		}
    }
}