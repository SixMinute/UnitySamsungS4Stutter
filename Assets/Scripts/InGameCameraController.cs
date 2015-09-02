//#define DEBUG_CAMERA_ZOOM

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InGameCameraController : MonoBehaviour 
{
	public Transform ballTrans;
	public Rigidbody2D rb;
	
////	public GameObject track;
//	public SMRect _LevelRect;
//
	Vector3 _CarPos;
//	Vector3 _TargetPosPrev;
//	Vector2 _CarVelocity;

	Vector3 _CameraPrevPos;

	private Camera _Camera;
	float _OrthographicSizeStart;

	public static float SMOOTH_CAMERA_FOLLOW_SPEED = 10f;

	private float _ZoomExtra;

	private Vector3 _CameraVelocity = Vector3.zero;




	// Use this for initialization
	void Awake () 
	{
		_Camera = GetComponent<Camera>();
		
		Application.targetFrameRate = -1;
	}

	
	public void LateUpdate()
	{
		_CarPos = getCarPosition();
	
		updateCameraSmoothFollow();//getCameraPosition());
	}
	
	public float dampTime = 0.3f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Update is called once per frame
	void updateCameraSmoothFollow () 
	{
		Camera camera = GetComponent<Camera>();
        if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
	
	bool updateCamera()
	{
		return true;
	}
	
	Vector3 getCarPosition()
	{
		return ballTrans.position;
		//return CoreGameController.getInstance().getCarPosition();
	}

	Vector2 getCarVelocity()
	{
		return rb.velocity;
		//return CoreGameController.getInstance().getCarVelocity();
	}

}
