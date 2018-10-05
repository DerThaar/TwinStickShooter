using UnityEngine;

public static class Utils
{


	public static float Map(float oldVal,
		float oldMin,
		float oldMax,
		float newMin,
		float newMax)
	{
		float oldRange = oldMax - oldMin;
		float newRange = newMax - newMin;
		float newVal = (((oldVal - oldMin) / oldRange) * newRange) + newMin;
		return newVal;
	}
}