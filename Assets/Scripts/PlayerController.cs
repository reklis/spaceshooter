using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
	public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour
{
	public float tilt = 4f;
	public float speed = 10f;

	public Boundry boundry;

	public GameObject shot;
	public Transform gunbarrel;
	public float fireRate = 0.25f;
	private float nextFire;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, gunbarrel.position, gunbarrel.rotation);
			audio.Play();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundry.xmin, boundry.xmax),
			0f,
			Mathf.Clamp(rigidbody.position.z, boundry.zmin, boundry.zmax)
		);

		rigidbody.rotation = Quaternion.Euler (0f, 0f, rigidbody.velocity.x * -tilt);
	}

}
