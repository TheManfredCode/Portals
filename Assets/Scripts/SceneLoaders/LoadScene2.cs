using UnityEngine;
using IJunior.TypedScenes;

public class LoadScene2 : MonoBehaviour, ISceneLoader
{
    public void Load()
    {
        Scene2.Load();
    }
}
