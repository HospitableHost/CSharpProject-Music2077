using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuadPool
{
    public static Stack<GameObject> pool = new Stack<GameObject>();

    public static GameObject Born(GameObject quad, Vector3 position, Quaternion quaternion)
    {
        if (pool.Count == 0)
        {
            GameObject res = MonoBehaviour.Instantiate(quad, position, quaternion);
            return res;
        }
        else
        {
            GameObject res = pool.Pop();
            res.SetActive(true);
            return res;
        }
    }

    public static void Die(GameObject gameObject)
    {
        gameObject.SetActive(false);
        LongQuadBehave longB = gameObject.GetComponent<LongQuadBehave>();
        ShortQuadBehave shortB = gameObject.GetComponent<ShortQuadBehave>();
        if (longB != null)
        {
            MonoBehaviour.Destroy(longB);
        }
        if (shortB != null)
        {
            MonoBehaviour.Destroy(shortB);
        }
        pool.Push(gameObject);
    }
}


