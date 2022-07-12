using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{

    AssetBundle loadedAssetBundle;
    public string path;
    public string assetName;

    void Start()
    {
        LoadAssetBundle(path);
        InstantiateObjectFromBundle(assetName);
    }

    void LoadAssetBundle(string bundleUrl)
    {
        loadedAssetBundle = AssetBundle.LoadFromFile(bundleUrl);

    }

    void InstantiateObjectFromBundle(string assetName)
    {
        //GameObject nameOfGameObeject = Instantiate(Resources.Load("preFab"), transform.position, new Quaternion()) as GameObject;
        //nameOfGameObject.position = newPosition;

        //public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace);

        var prefab = loadedAssetBundle.LoadAsset(assetName);
        Instantiate(prefab, transform.parent);
    }

}
