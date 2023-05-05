using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
	public RectTransform CompassTransform;

	public RectTransform ReferenceCompass;
    public RectTransform NorthMarkerTransform;
    public RectTransform SouthMarkerTransform;
	public RectTransform WestMarkerTransform;
	public RectTransform EastMarkerTransform;
	
	public Transform cameraObjectTransform;
    public Transform objectiveObjectTransform;

	void Update()
    {
		SetMarkerPosition(ReferenceCompass, objectiveObjectTransform.position);
		SetMarkerPosition(NorthMarkerTransform, Vector3.forward * 1000);
		SetMarkerPosition(SouthMarkerTransform, Vector3.back * 1000);
		SetMarkerPosition(WestMarkerTransform, Vector3.left * 1000);
		SetMarkerPosition(EastMarkerTransform, Vector3.right * 1000);
	}

	private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
	{
		Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
		float angle = Vector2.Angle(new Vector2(directionToTarget.x, directionToTarget.z), 
            new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compassPositionX = Mathf.Clamp(1 * angle / Camera.main.fieldOfView, -2, 2);
		markerTransform.anchoredPosition = new Vector2(CompassTransform.rect.width / 2 * compassPositionX, 1);
	}
}


