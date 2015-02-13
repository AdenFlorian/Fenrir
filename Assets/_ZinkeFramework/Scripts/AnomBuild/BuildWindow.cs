using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class AnomBuildWindow : EditorWindow {
	string exeName = "MyGame";
	string buildsFolder = "C:\\";
	bool groupEnabled;
	bool buildThenRun = false;
	int buildNumber = 1;
	public string[] levels = { "Assets/_Fenrir/Scenes/Main.unity" };
	BuildTarget[] buildTargets = { BuildTarget.WebPlayer, BuildTarget.StandaloneWindows };

	// Add menu item
	[MenuItem("Window/AnomBuild")]
	[MenuItem("Anomalus/AnomBuild")]
	public static void ShowWindow() {
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(AnomBuildWindow));
	}

	void OnGUI() {
		if (GUILayout.Button("Select Builds Folder")) {
			buildsFolder = EditorUtility.SaveFolderPanel("Choose Builds Folder", "", "");
		}

		EditorGUILayout.TextField("Builds Folder", buildsFolder);

		if (GUILayout.Button("Build")) {
			BuildGame();
		}
	}


	void BuildGame() {

		// Build game(s)
		foreach (BuildTarget buildTarget in buildTargets) {
			BuildPipeline.BuildPlayer(levels, buildsFolder + "/" +
				buildNumber + "/" + buildTarget.ToString() + "/" + exeName,
				buildTarget, BuildOptions.None);
		}

		// Copy a file from the project folder to the build folder, alongside the built game.
		//FileUtil.CopyFileOrDirectory("Assets/WebPlayerTemplates/Readme.txt", path + "Readme.txt");

		// Run the game
		if (buildThenRun) {
			Process proc = new Process();
			proc.StartInfo.FileName = buildsFolder + "/" + exeName;
			proc.Start();
		}

		buildNumber++;
	}
}