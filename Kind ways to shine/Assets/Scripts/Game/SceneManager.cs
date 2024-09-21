using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<GameObject> scenes;

    public void AddScene(GameObject scene)
    {
        scenes.Add(scene);
        // Additional logic to update the UI
    }

    public void RemoveScene(GameObject scene)
    {
        scenes.Remove(scene);
        // Additional logic to update the UI
    }
}
