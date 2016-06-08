using UnityEngine;
using System.Collections;

public class move3 : MonoBehaviour {
	private float radian=0;
	public float perRadian = 0.02f;
	public float radius =0.5f;
	private Vector3 oldPos;
	// Use this for initialization
	void Start () {
		oldPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		radian += perRadian;
		float dy = Mathf.Cos (radian);
		transform.position = oldPos + new Vector3 (dy, 0, 0);
	}
}
