using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public interface IResetable
{
    void OnReset();
}
public class GameObjectPool : UnitySingleton<GameObjectPool>
{

    //1 创建池
    private Dictionary<string, List<GameObject>> cache =
    new Dictionary<string, List<GameObject>>();
    //2 创建使用池的元素【游戏对象】一个对象并使用对象:
    //池中有从池中返回;池中没有加载，放入池中再返回   
    public GameObject CreateObject(string key, GameObject go,
        Vector3 positon, Quaternion quaternion)
    {
        //1)查找池中有无可用游戏对象
        GameObject temoGo = FindUsable(key);
        //2)池中有从池中返回;
        if (temoGo != null)
        {
            temoGo.transform.position = positon;
            temoGo.transform.rotation = quaternion;
            temoGo.SetActive(true);//表示当前这个游戏对象在使用中
        }
        else//3)池中没有加载，放入池中再返回
        {
            temoGo = GameObject.Instantiate(go, positon, quaternion) as GameObject;
            //放入池中
            Add(key, temoGo);
        }
        //作为池物体的子物体
        temoGo.transform.parent = this.transform;
        //初始化物体
        if(temoGo.GetComponent<IResetable>() != null)
            temoGo.GetComponent<IResetable>().OnReset();

        return temoGo;//返回物体
    }
    private GameObject FindUsable(string key)
    {
        if (cache.ContainsKey(key))
        {
            //在列表中找出未激活的游戏物体 
            return cache[key].Find(p => !p.activeSelf);
        }
        return null;
    }
    private void Add(string key, GameObject go)
    {
        //先检查池中是否 有需要的key，没有，需要向创建key和对应的列表。
        if (!cache.ContainsKey(key))
        {
            cache.Add(key, new List<GameObject>());
        }
        //把游戏对象添加到 池中
        cache[key].Add(go);
    }

    //3 释放资源：从池中删除对象！
    //3.1释放部分：按Key释放 
    public void Clear(string key)
    {
        if (cache.ContainsKey(key))
        {
            //释放场景中 的游戏物体
            for (int i = 0; i < cache[key].Count; i++)
            {Destroy(cache[key][i]); }
            //移除了对象的地址
            cache.Remove(key);

            //释放场景中 的游戏物体
            for (int i = cache[key].Count - 1; i >= 0; i--)
            { Destroy(cache[key][i]); }
            //移除了对象的地址
            cache.Remove(key);
        }
    }
    //3.2释放全部 循环调用Clear(string key)
    public void ClearAll()
    {
        //
        List<string> keys = new List<string>(cache.Keys);
        for (int i = 0; i < keys.Count; i++)
        {
            Clear(keys[i]);
        }
        //foreach (var a in keys)
        //{
        //    Clear(a);
        //}
    }
    //4 回收对象：使用完对象返回池中【从画面中消失】
    //4.1即时回收对象
    public void CollectObject(GameObject go)
    {
        go.SetActive(false);//本质：画面小时 设置属性
    }

    public void CollectObject(GameObject go, float delay = 0)
    {
        StartCoroutine(CollectDelay(go, delay));

    }

    //4.2延时回收对象 等待一定的时间 协程
    //public void CollectObject(GameObject go, float delay)
    //{
    //    StartCoroutine(CollectDelay(go, delay));
    //}
    private IEnumerator CollectDelay(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);

    }
}


