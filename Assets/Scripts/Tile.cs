using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour  {
	public int x { get; protected set; }
	public int y { get; protected set; }

	virtual public Tile[] getNeighbors() {
		return null;
	}
}
