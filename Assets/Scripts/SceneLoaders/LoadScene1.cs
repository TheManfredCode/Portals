using UnityEngine;
using IJunior.TypedScenes;

public class LoadScene1 : MonoBehaviour, ISceneLoader
{
    public void Load()
    {
        Scene1.Load();
    }
}
