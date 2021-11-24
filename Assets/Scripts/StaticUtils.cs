using UnityEngine;

public class StaticUtils : MonoBehaviour
{
    public readonly float G = 6.67408e-11f;
    public readonly float gravityScale = 1e12f;

    private static StaticUtils _Instance = null;

    public static StaticUtils GetInstance()
    {
        if (_Instance == null)
        {
            GameObject go = new GameObject();
            _Instance = go.AddComponent<StaticUtils>();
        }
        return _Instance;
    }
}
