using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public int scoreValue;

	private GameController gameController;

	public GameObject explosion;
	public GameObject playerExplosion;

	void Start ()
	{
		gameController = GameObject.FindObjectOfType<GameController> ();

		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if (other.tag == "Player")
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.EndGame();
		}

		gameController.AddScore (scoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
