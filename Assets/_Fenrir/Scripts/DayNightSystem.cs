using UnityEngine;
using System.Collections;

public class DayNightSystem : MonoBehaviour {

	public GameObject sunDLight;
	public GameObject moonDLight;

	float timeOfDay; // From 0.0f to 1.0f, 0.0f being midnight, 0.5f being noon
	float dayLength = 60; // Seconds

	void Awake () {
	}
	
	void Start () {
		
	}
	
	void Update () {
		// Advance time
		timeOfDay += Time.deltaTime / dayLength;
		if (timeOfDay >= 1.0f) {
			timeOfDay -= 1.0f;
		}
		// Rotate DLights
		sunDLight.transform.eulerAngles = new Vector3(timeOfDay * 360f, 0f, 0f);
		moonDLight.transform.eulerAngles = new Vector3((timeOfDay * 360f) + 180f, 0f, 0f);
		DebugUI.Inst.AddLine("TimeOfDay: " + timeOfDay.ToString("P"));
	}
}
