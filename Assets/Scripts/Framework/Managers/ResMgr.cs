using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//资源管理器 加载资源..
public enum AssetsType
{
    UI = 0,
    Map = 1,
    Char = 2,
    Prop = 3
}
public class ResMgr : UnitySingleton<ResMgr>
{
   public override void Awake()
    {
        base.Awake();
    }

    public T GetAssetsCache<T>(string name) where T : UnityEngine.Object
    {
# if UNITY_EDITOR
//编辑器模式加载资源。。
        if (true)
        {
            string path = "Assets/AssetsPackage/" + name ;
            Debug.Log(path);
            UnityEngine.Object target = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            return (T)target;
        }

#endif
        
    }
    public T GetMapAssets<T>(AssetsType assetsType,string name) where T : UnityEngine.Object
    {
        string root = null;
        switch (assetsType)
        {
            case AssetsType.UI:
                root = "Assets/AssetsPackage/GUI/UIPrefabs/";
                break;
            case AssetsType.Map:
                root = "Assets/AssetsPackage/Maps/";
                break;
            case AssetsType.Char:
                root = "Assets/AssetsPackage/Char/";
                break;
            case AssetsType.Prop:
                root = "Assets/AssetsPackage/Props/";
                break;
        }
#if UNITY_EDITOR
        //编辑器模式加载资源。。
        if (true)
        {
            string path = root + name + ".prefab";
            Debug.Log(path);
            UnityEngine.Object target = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
            return (T)target;
        }

#endif
    }

}
