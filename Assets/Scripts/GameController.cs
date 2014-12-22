using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private int score;
	public Text scoreText;

	public Text gameOverText;
	public Button retryButton;
	public Text retryButtonText;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				SpawnOne ();
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void SpawnOne ()
	{
		Vector3 spawnPosition = new Vector3
		(
			Random.Range (-spawnValues.x, spawnValues.x),
			spawnValues.y,
			spawnValues.z
		);
		
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}
	
	
	public void AddScore(int s)
	{
		score += s;
		scoreText.text = "Score: " + score;
	}

	public void EndGame()
	{
		gameOverText.enabled = true;
		retryButton.enabled = true;
		retryButton.image.enabled = true;
		retryButtonText.enabled = true;
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
