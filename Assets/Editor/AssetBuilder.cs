using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetBuilder : MonoBehaviour
{
    [MenuItem("Assets/Get AssetBundle Names")]
    static void GetAssetBundleNames()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach(var name in names)
        {
            Debug.Log($"AssetBundle:{name}");
        }
    }

    [MenuItem("Assets/Build Asset Bunbles")]
    static void BuildAssets()
    {
        var path = "Assets/Bundle/Win";

        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }

        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
