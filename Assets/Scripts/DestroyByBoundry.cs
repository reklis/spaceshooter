using UnityEngine;
using System.Collections;

public class DestroyByBoundry : MonoBehaviour
{
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			return;
		}

		Destroy (other.gameObject);
	}
}
