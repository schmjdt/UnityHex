using UnityEngine;
using System.Collections;

public class map : MonoBehaviour {

	public GameObject hexPrefab;

	public Vector2 mapSize;
	public Vector2 rowOffset;
	// 1.53 x .431

	// Use this for initialization
	void Start () {
		for (int x = 0; x < mapSize.x; x++) {
			for (int y = 0; y < mapSize.y; y++) {

				float xPos = x * rowOffset.x;
				if (y % 2 == 1) 
				{
					xPos += (rowOffset.x * .5f);
				}

				GameObject gObj = (GameObject) Instantiate(hexPrefab, new Vector3(xPos,0,y * rowOffset.y), Quaternion.identity);
				gObj.transform.SetParent(this.transform);
				gObj.name = "hex_" + x + "_" + y;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
