using UnityEngine;
using System.Linq;
using Object = UnityEngine.Object;

namespace CrowStudiosCase.Utils
{
    public static class SingletonMonoBehaviour
    {
        public static T GetInstance<T>() where T : Behaviour
        {
            var instance = Object.FindObjectOfType<T>();
	
            if (instance == null)
            {
                var obj = new GameObject(typeof(T) + "_Instance");
                Object.DontDestroyOnLoad(obj);
                instance = obj.AddComponent<T>();
            }
	
            return instance;
        }
    }

    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static bool didCacheInstance = false;
        protected static T instance;

        public static T Instance => instance;
        
        protected bool SetupInstance(bool persistOnLoad = true)
        {
            instance = (T)this;
            if (persistOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }

            return true;
        }
    }
}