
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public BalloonController Balloon;
    private Vector3 PositionOffset;

    private void Start()
    {
        PositionOffset = transform.position - Balloon.transform.position;
    }

    void LateUpdate()
	{
        transform.position = PositionOffset + Balloon.transform.position;
	}
    
	
}























