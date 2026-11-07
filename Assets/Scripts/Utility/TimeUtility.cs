using UnityEngine;

public class TimeUtility : MonoBehaviour
{
    public static class GameTime
    {
        public static float DeltaTime => UnityEngine.Time.deltaTime;

        public static float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
    }

    /// <summary>
    /// ƒŠƒAƒ‹ŠÔ
    /// </summary>
    public static class RealTime
    {
        public static float DeltaTime => UnityEngine.Time.unscaledDeltaTime;
    }
}
