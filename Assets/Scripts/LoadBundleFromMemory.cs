using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadBundleFromMemory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLoad());
    }

    private IEnumerator StartLoad()
    {
        string path = "Assets/Bundle/Win/scene/model.ab";

        // aynsc load
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return request;

        AssetBundle assetBundle = request.assetBundle;

        // sync load
        //AssetBundle assetBundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));

        var obj = assetBundle.LoadAllAssets<GameObject>();

        foreach (var o in obj)
        {
            Instantiate(o);
        }
    }
}
