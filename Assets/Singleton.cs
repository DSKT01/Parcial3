using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontDestroy
{
    public class Singleton : MonoBehaviour
    {
        public static int vida = 10;

        static Singleton _instance;
        // Use this for initialization
        void Awake()
        {
            if (_instance == null)
            { _instance = this; DontDestroyOnLoad(gameObject); }
            else
                Destroy(gameObject);
        }
    }
}
