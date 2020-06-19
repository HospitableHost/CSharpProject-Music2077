using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    GameObject number1;
    GameObject number2;
    GameObject number3;
    GameObject start;

    private void Start()
    {
        Debug.Log("having readyToStart");
        GameObject q = Resources.Load<GameObject>("Prefabs/number1Text");
        //Debug.Log(1);
        number1 = MonoBehaviour.Instantiate(q, new Vector3(0, 0, 50.0f), new Quaternion());

        //Debug.Log(2);
        q = Resources.Load<GameObject>("Prefabs/number2Text");
        number2 = MonoBehaviour.Instantiate(q, new Vector3(0, 0, 50.0f), new Quaternion());

        q = Resources.Load<GameObject>("Prefabs/number3Text");
        number3 = MonoBehaviour.Instantiate(q, new Vector3(0, 0, 50.0f), new Quaternion());

        q = Resources.Load<GameObject>("Prefabs/startText");
        start = MonoBehaviour.Instantiate(q, new Vector3(0, 0, 50.0f), new Quaternion());
        StartCoroutine(Count());
    }
    private IEnumerator Count()
    {
        Time.timeScale = 0;
        Debug.Log("Count start");
        for (float t = 0; t <= 55.0f; t += 1f)
        {
            Debug.Log("携程");
            number3.transform.position -= new Vector3(0, 0, 1f);
            yield return 0;
        }
        for (float t = 0; t <= 55.0f; t += 1f)
        {
            Debug.Log("携程");
            number2.transform.position -= new Vector3(0, 0, 1f);
            yield return 0;
        }
        for (float t = 0; t <= 55.0f; t += 1f)
        {
            Debug.Log("携程");
            number1.transform.position -= new Vector3(0, 0, 1f); ;
            yield return 0;
        }
        for (float t = 0; t <= 55.0f; t += 1f)
        {
            Debug.Log("携程");
            start.transform.position -= new Vector3(0, 0, 1f);
            yield return 0;
        }
        //nowPos.Set(0.3f, 0.6f, 50f);
        //for (float t = 0; t <= 10.0f; t += 1.0f)
        //{
        //    nowPos.Set(nowPos.x, nowPos.y, nowPos.z - 100 * Time.deltaTime);
        //    number2.transform.position = nowPos;
        //}
        //nowPos.Set(0.3f, 0.6f, 50f);
        //for (float t = 0; t <= 10.0f; t += 1.0f)
        //{
        //    nowPos.Set(nowPos.x, nowPos.y, nowPos.z - 100 * Time.deltaTime);
        //    number1.transform.position = nowPos;
        //}
        //nowPos.Set(0.3f, 0.6f, 50f);
        //for (float t = 0; t <= 10.0f; t += 1.0f)
        //{
        //    nowPos.Set(nowPos.x, nowPos.y, nowPos.z - 100 * Time.deltaTime);
        //    start.transform.position = nowPos;
        //}

    }
}
