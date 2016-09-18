using UnityEngine;
using System.Collections.Generic;

public class Timer
{
	private float lifeTime = 0f;//время срабатывания в секундах
	private float _creationTime = 0f;//время создания таймера

	public Timer()
	{
		_creationTime = Time.time;
	}

	public Timer(float life)
	{
		_creationTime = Time.time;
		lifeTime = life;
	}

	public bool Check()
	{
		return (Time.time - _creationTime >= lifeTime);
	}
};

public struct tMode
{
	public const int FindOrCreate = 0;
}

//синглтон
public class TimerSystem {

	private static TimerSystem _instance = null;
	private Dictionary<string, Timer> timers;


	public static TimerSystem Instance
	{
		get
		{
			if (_instance == null)
				_instance = new TimerSystem ();
			return _instance;
		}
	}

	private TimerSystem()
	{
		timers = new Dictionary<string, Timer> ();
	}

	public bool CheckTimer(string id, float lifetime = 0f, int mode = tMode.FindOrCreate)
	{
		switch (mode)
		{
		case tMode.FindOrCreate:
			if(timers.ContainsKey(id))//таймер с таким айди уже существует, проверяем, не сработал ли он
			{
				if (timers [id].Check ())//если сработал
				{
					timers.Remove(id);//он больше не нужен
					Debug.Log("Сработал таймер");
					return true;//возвращаем
				}
				else return false;
			}
			else//создаём таймер с таким айди
			{
				Timer t = new Timer(lifetime);
				timers.Add(id, t);
				return timers [id].Check ();
			}
		}

		Debug.Log ("Мы не должны были сюда дойти;)");
		return false;
	}

	public void Clear()
	{
		_instance = null;
		timers.Clear ();
	}
}
