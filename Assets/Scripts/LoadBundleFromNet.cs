using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadBundleFromNet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLoad());
    }

    private IEnumerator StartLoad()
    {
        while (!Caching.ready)
        {
            yield return null;
        }

        string url = "http://localhost:10012/scene/model.ab";

        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return www.SendWebRequest();

        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(www);

        Instantiate(assetBundle.LoadAsset("Capsule"), Vector3.one, Quaternion.identity);

        AssetBundleRequest request = assetBundle.LoadAssetAsync("Cube", typeof(GameObject));
        yield return request;

        Instantiate(request.asset as GameObject);

        assetBundle.Unload(false);

        www.Dispose();
    }
}
