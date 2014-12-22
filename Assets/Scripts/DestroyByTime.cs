using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
	public float lifeTime = 1f;

	void Start()
	{
		Destroy(gameObject, lifeTime);
	}
}
