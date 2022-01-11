using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{

	[Header("Resources")]
	public UnityEngine.Experimental.Rendering.Universal.Light2D worldLight;

	[Min(2)]
	public float minutesPerDay;
	[Range(0, 1)]
	private float lightValue;
	public bool alwaysLight;

	public LightingSettings lightingSettings;
	public Material daySkybox;
	public Material blendSkybox;
	public Material nightSkybox;

	/**<summary>Used for storing the End of the Day</summary>*/
	private DateTime ended;

	/**<summary>Calls: <see cref="Recalc"/></summary>*/
	private void Start()
	{
		if (alwaysLight)
		{
			RenderSettings.skybox = daySkybox;
			worldLight.intensity = 1;
			worldLight.transform.rotation = Quaternion.Euler(90, 0, 0);
		}
		else
			ended = DateTime.UtcNow.AddMinutes(minutesPerDay / 2);
	}

	/**<summary>Sets the ended variable</summary>*/
	public void Recalc()
	{
		ended = DateTime.UtcNow.AddMinutes(minutesPerDay);
	}

	public double GetMinute()
	{
		return -(DateTime.UtcNow - ended).TotalMinutes;
	}
	public double GetMinuteFrom0()
	{
		return minutesPerDay + (DateTime.UtcNow - ended).TotalMinutes;
	}

	//f(x) = -1/64 * (x - 8)^2 +1

	/**<summary>Calculates the Light intensity.</summary>*/
	public void Update()
	{
		if (alwaysLight)
			return;
		if (ended <= DateTime.UtcNow)
			Recalc();

		//sets the Skybox
		float blendtime = minutesPerDay / 8;

		if (GetMinuteFrom0() <= minutesPerDay / 4 - blendtime / 2 || GetMinuteFrom0() >= 3 * minutesPerDay / 4 + blendtime / 2)
		{
			RenderSettings.skybox = nightSkybox;
		}
		else if (GetMinuteFrom0() > minutesPerDay / 4 + blendtime / 2 && GetMinuteFrom0() < 3 * minutesPerDay / 4 - blendtime / 2)
		{
			RenderSettings.skybox = daySkybox;
		}
		else
			RenderSettings.skybox = blendSkybox;


		float angle = 0f;

		if ((GetMinuteFrom0() < minutesPerDay / 4) || (GetMinuteFrom0() > (3 * minutesPerDay) / 4))
			worldLight.enabled = false;
		else
			worldLight.enabled = true;

		angle = (float)((360 / minutesPerDay) * GetMinuteFrom0()) - 90;
		//Debug.Log($"{GetMinuteFrom0()}, {minutesPerDay / 4}, {(3 * minutesPerDay) / 4}, {angle}");
		if (worldLight.enabled)
			worldLight.transform.rotation = Quaternion.Euler(angle, 0, 0);

		double a = -16 / Math.Pow(minutesPerDay, 2);

		worldLight.intensity = (float)(a * Math.Pow((GetMinuteFrom0() - minutesPerDay / 2), 2) + 1);
		//Debug.Log(worldLight.intensity);
		//worldLight.intensity = (float)(Math.Pow((ended - DateTime.UtcNow).TotalMinutes - minutesPerDay / 2, 2) / -Math.Pow(minutesPerDay / 2, 2) + 1);
	}
}
