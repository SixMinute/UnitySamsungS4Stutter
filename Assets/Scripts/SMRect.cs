using UnityEngine;
using System.Collections;

[System.Serializable]
public class SMRect
{
	public float minX;
	public float minY;
	public float maxX;
	public float maxY;

	public SMRect(float minX, float minY, float maxX, float maxY)
	{
		this.minX = minX;
		this.minY = minY;
		this.maxX = maxX;
		this.maxY = maxY;
	}

	public static SMRect fromBounds(Bounds bounds)
	{
		return new SMRect(bounds.min.x, bounds.min.y ,bounds.max.x, bounds.max.y);
	}
}
