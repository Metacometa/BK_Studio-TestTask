using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour, ISceneObjectProvider
{
    public List<SceneObject> objects;

    public void Init()
    {
        objects = new List<SceneObject>(FindObjectsOfType<SceneObject>());
    }

    public List<SceneObject> GetSceneObjects()
    {
        return objects;
    }
}
