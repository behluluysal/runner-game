using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    public static GemSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
    }
    public void SpawnGem(GameObject Parent, int type)
    {
        try
        {
            Transform typeObj = Parent.transform.transform.Find($"Type{type}");
            typeObj.gameObject.SetActive(true);
            typeObj = typeObj.Find("Collectables");

            foreach (Transform child in typeObj)
            {
                GameObject obstacle = _objectPooler.SpawnFromPool(PoolObjects.Gem, new Vector3(0, 0, 0), Quaternion.identity);
                obstacle.transform.parent = child;
                obstacle.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("ete");
            throw;
        }

    }
    public void SetGemsFalse(GameObject Parent)
    {
        Transform typeObj;
        GameObject obj;
        try
        {
            typeObj = Parent.transform.Find(GetActiveChild(Parent.transform)).Find("Collectables");

            foreach (Transform child in typeObj)
            {
                //First 3 roads don't have gems. Check for error handling
                Transform gem = child.Find("Diamond5side(Clone)");
                if (gem != null)
                {
                    obj = gem.gameObject;
                    obj.transform.parent = null;
                    obj.SetActive(false);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
    }
    private void SetAllChildsFalse(Transform ParentTransform)
    {
        foreach (Transform child in ParentTransform)
        {
            if (child.tag == "PlayArea")
                child.gameObject.SetActive(false);
        }
    }
    private string GetActiveChild(Transform ParentTransform)
    {
        foreach (Transform child in ParentTransform)
        {
            if (child.gameObject.activeSelf && child.tag == "PlayArea")
                return child.transform.name;
        }
        return string.Empty;
    }
}
