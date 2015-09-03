using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	
	public float _MaxY;
	public float _MinY;
	private bool _DirUp;
	private float _CurrentY;
	private Vector3 _LocalVector;
	
	// Use this for initialization
	void Start () 
	{
		_CurrentY = _MaxY;
		_DirUp = false;
		_LocalVector = new Vector3();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distanceThisFrame = 10.0f * Time.deltaTime;
	//	Debug.Log(_CurrentY + " sdsdsds ");
		if(_DirUp)
		{
			_CurrentY += distanceThisFrame;
			
			if(_CurrentY > _MaxY)
			{
				_CurrentY = _MaxY;
				_DirUp = false;
			}
		}
		else
		{
			_CurrentY -= distanceThisFrame;
			
			if(_CurrentY < _MinY)
			{
				_CurrentY = _MinY;
				_DirUp = true;
			}
		}

		_LocalVector.Set(transform.position.x, _CurrentY, transform.position.z);
		
		transform.position = _LocalVector;
	}
}
