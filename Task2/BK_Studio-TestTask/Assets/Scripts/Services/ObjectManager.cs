using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour, ISceneObjectProvider
{
    public List<ISceneObject> objects;

    public void Init()
    {
        objects = new List<ISceneObject>(FindObjectsOfType<SceneObject>());
    }

    public List<ISceneObject> GetSceneObjects()
    {
        return objects;
    }
}
