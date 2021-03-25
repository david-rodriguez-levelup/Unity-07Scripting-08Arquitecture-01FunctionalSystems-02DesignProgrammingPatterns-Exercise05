using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance != null)
            {
                Debug.Log($"Return the instance for singleton<{typeof(T)}>!");
                return _instance;
            }
            else
            {
                _instance = FindObjectOfType<T>();
                if (_instance != null)
                {
                    Debug.Log($"Instance FOUND for singleton<{typeof(T)}>!");
                    return _instance;
                }
                else
                {
                    Debug.Log($"NEW instance for singleton<{typeof(T)}>!");
                    GameObject container = new GameObject($"{typeof(T)}", typeof(T));
                    _instance = container.GetComponent<T>();
                    return _instance;
                }
            }
        }
    }

    private static T _instance;

    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this as T;
        }
    }

}
