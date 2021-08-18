using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class LoadScene3 : MonoBehaviour, ISceneLoader
{
    public void Load()
    {
        Scene3.Load();
    }
}
