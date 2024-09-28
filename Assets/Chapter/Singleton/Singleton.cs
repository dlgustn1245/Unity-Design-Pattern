using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Singleton
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		static T instance;

		public static T Instance
		{
			get
			{
				if (instance is null)
				{
					instance = FindObjectOfType<T>();

					if (instance is null)
					{
						var obj = new GameObject
						{
							name = typeof(T).Name
						};
						instance = obj.AddComponent<T>();
					}
				}

				return instance;
			}
		}

		protected virtual void Awake()
		{
			print("Singleton.Awake");
			if (instance is null)
			{
				instance = this as T;
				DontDestroyOnLoad(instance);
			}
			else
			{
				Destroy(instance);
			}
		}
	}
}