using UnityEngine;
using System.Collections;
using Rotorz.Tile;


public class DontLeaveMap : CacheBehaviour
{
	// this class assumes a sprite with a bottom/center pivot point.

	public GameObject tileMap;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float leftOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float rightOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float upperOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float lowerOffset;

	private float rightBound;
	private float leftBound;
	private float upperBound;
	private float lowerBound;
	private TileSystem tileSystem;

	void Start()
	{
		base.CacheComponents();

		tileSystem = tileMap.GetComponent<TileSystem>();

		Vector3 tileSystemSize = new Vector3(
		    tileSystem.ColumnCount * tileSystem.CellSize.x,
		    tileSystem.RowCount * tileSystem.CellSize.y,
		    tileSystem.CellSize.z
		);

		leftBound = 0f;
		rightBound = tileSystemSize.x;
		lowerBound = -(tileSystemSize.y);
		upperBound = 0f;
	}

	void LateUpdate ()
	{
		// check left bound.
		if (transform.position.x - (renderer.bounds.size.x / 2 - leftOffset) < leftBound)
			transform.position = new Vector3(leftBound + (renderer.bounds.size.x / 2  - leftOffset), transform.position.y, transform.position.z); 

		// check right bound.
		if (transform.position.x + (renderer.bounds.size.x / 2 - rightOffset) > rightBound)
			transform.position = new Vector3(rightBound - (renderer.bounds.size.x / 2 - rightOffset), transform.position.y, transform.position.z); 

		// check upper bound.
		if (transform.position.y + (renderer.bounds.size.y - upperOffset) > upperBound)
			transform.position = new Vector3(transform.position.x, upperBound - (renderer.bounds.size.y - upperOffset), transform.position.z); 
		
		// check lower bound.
		if (transform.position.y - lowerOffset < lowerBound)
			transform.position = new Vector3(transform.position.x, lowerBound - lowerOffset, transform.position.z); 
	}
}
