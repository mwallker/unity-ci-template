using System.Collections.Generic;
using UnityEditor;

public class Builder
{
  public static void ReleaseWindows()
  {
    BuildPlayerOptions buildPlayerOptions = new()
    {
      scenes = GetEnabledScenes(),
      locationPathName = $"Builds/Windows/{PlayerSettings.productName}.exe",
      target = BuildTarget.StandaloneWindows64,
      options = BuildOptions.None
    };

    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }

  public static void ReleaseWebGL()
  {
    BuildPlayerOptions buildPlayerOptions = new()
    {
      scenes = GetEnabledScenes(),
      locationPathName = $"Builds/WebGL/{PlayerSettings.productName}",
      target = BuildTarget.WebGL,
      options = BuildOptions.None
    };

    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }

  public static void ReleaseAndroid()
  {
    BuildPlayerOptions buildPlayerOptions = new()
    {
      scenes = GetEnabledScenes(),
      locationPathName = $"Builds/Android/{PlayerSettings.productName}.apk",
      target = BuildTarget.Android,
      options = BuildOptions.None,
    };

    PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
    PlayerSettings.Android.bundleVersionCode++;

    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }

  public static void ReleaseIOS()
  {
    BuildPlayerOptions buildPlayerOptions = new()
    {
      scenes = GetEnabledScenes(),
      locationPathName = $"Builds/iOS/{PlayerSettings.productName}",
      target = BuildTarget.iOS,
      options = BuildOptions.None,
    };

    BuildPipeline.BuildPlayer(buildPlayerOptions);
  }

  // Helper method to get the paths of all scenes in the project
  private static string[] GetEnabledScenes()
  {
    List<string> ScenePaths = new();

    for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
    {
      if (EditorBuildSettings.scenes[i].enabled)
      {
        ScenePaths.Add(EditorBuildSettings.scenes[i].path);
      }
    }

    return ScenePaths.ToArray();
  }
}