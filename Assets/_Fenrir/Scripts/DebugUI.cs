using UnityEngine;
using System.Collections;

public class DebugUI : MonoBehaviour {

	public static DebugUI Inst;
	public UnityEngine.UI.Text uiText;
	public bool display = false;

	void Awake () {
		Inst = this;

		if (!Debug.isDebugBuild) {
			display = false;
		}
	}
	
	void Start () {
	}

	void Update() {
		uiText.text = "";
	}

	public void AddLine(string line) {
		if (display) {
			uiText.text += line + "\n";
	    }
	}
}
