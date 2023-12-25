using System;
using UnityEngine;

public abstract class Test<T> where T :new()
{
    private static T instance;
    private static object obj;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                lock (obj)
                {
                    if(instance == null)
                        instance = new T();
                }
            }
            return instance;
        }
    }
}

public class TestMonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectsOfType(typeof(T)) as T;
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent(typeof(T)) as T;
                    obj.name = typeof(T).Name;    
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = this as T;
        else
            Destroy(this.gameObject);
    }
}

public static class Test2<T>  where T :new()
{
    private static T instance;
    private static object obj = new object();

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                        instance = new T();
                }
            }
            return instance;
        }
    }

}

public class Mono2Singleton<T> : MonoBehaviour where T : Mono2Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameLaunch.FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    instance = new GameObject((typeof(T)).Name).AddComponent<T>();
                }

                instance.Init();
            }

            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
            instance = this as T;
        this.Init();
    }

    public virtual void Init() { }
}

