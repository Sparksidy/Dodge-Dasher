using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start()
	{
		//Camera.main.orthographicSize = (float)Screen.currentResolution.height / 80 / 2;
	}

	/*void OnGUI()
	{
		float horizRatio = Screen.width / 1024.0f;
		float vertRatio = Screen.height / 768.0f;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(horizRatio, vertRatio, 1.0f));
	}*/
}
