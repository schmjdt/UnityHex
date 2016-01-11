using UnityEngine;
using System.Collections;

public class Hex : Tile {

	public Hex[] getNeighbors() {

		GameObject leftNeighbor = GameObject.Find("Hex_" + (x-1) + "_" + y);
		GameObject rightNeighbor = GameObject.Find("Hex_" + (x+1) + "_" + y);

		// Even: x-1 & x  OR  Odd: x and x+1
		return null;
	}
}
