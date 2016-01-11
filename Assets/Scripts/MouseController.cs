using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour {

	Unit selectedUnit;

	Vector3 lastFramePosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// If mouse is over UI Element
		if (EventSystem.current.IsPointerOverGameObject()) return;
		// Can also check if game is paused / menu / ect.

		if (Input.GetMouseButton(1) || Input.GetMouseButton(2)) {
			// Pan view around
			MoveCamera();
		} else {
			// Mouse Over 
			FindMouseOver();
		}

		lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void MoveCamera() {
		Debug.Log("MousePosit: " +  Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector3 diff = lastFramePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Camera.main.transform.Translate(diff);
	}

	void FindMouseOver() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hitInfo;

		if (Physics.Raycast(ray, out hitInfo)) {
			GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;

			Debug.Log("Raycast Hit: " + ourHitObject.name);

			// What kind of object?
			if (ourHitObject.GetComponentInChildren<Hex>() != null) 	MouseOver_Hex(ourHitObject); 
			if (ourHitObject.GetComponentInChildren<Unit>() != null) 	MouseOver_Unit(ourHitObject);

		}
	}


	void MouseOver_Hex(GameObject hitObj) {
		// Mouse over
		// Can show tooltip or something?

		// If we click
		if (Input.GetMouseButtonDown(0)) {

			if (selectedUnit != null) {
				selectedUnit.destination = hitObj.transform.position;
				return;
			}

			swapColor(hitObj, Color.white, Color.red);
		}
	}

	void MouseOver_Unit(GameObject hitObj) {
		if (Input.GetMouseButtonDown(0)) {
			swapColor(hitObj, Color.black, Color.blue);

			// Can only select unit if no other unit is selected
			//	May want to change how this is implemented
			if (selectedUnit == null)
				selectedUnit = hitObj.GetComponentInChildren<Unit>();
			else 
				selectedUnit = null;
		}
	}




	void swapColor(GameObject gO, Color c1, Color c2) {
		MeshRenderer mr = gO.GetComponentInChildren<MeshRenderer>();
		if (mr.material.color == c1) {
			mr.material.color = c2;
		} else {
			mr.material.color = c1;
		}
	}
}
