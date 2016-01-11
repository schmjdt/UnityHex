using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public float speed = 2;

	public Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = destination - transform.position;
		Vector3 velocity = dir.normalized * speed * Time.deltaTime;

		// Make sure the velocity doesn't actually exceed the distance we want.
		velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

		transform.Translate(velocity);
	}
}
