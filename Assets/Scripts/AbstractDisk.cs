using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractDisk : MonoBehaviour {

    public int Rode { get; private set; }
    public int Place { get; private set; }

	public virtual  Vector3 GetSize()
    {
        return Vector3.zero;
    }

    public virtual IEnumerator Draw(float travelTime=0)
    {
        var start = transform.localPosition;
        var end = new Vector3((Rode - 1) * GetSize().x / transform.localScale.x * 2, GetSize().y * Place);
        float time = 0;
        while (time<travelTime)
        {
            time += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(start, end, time/travelTime);
            yield return null;
        }
        transform.localPosition = end;
        yield return null;
    }

    public void Move(int rode,int place)
    {
        Rode = rode;
        Place = place;
    }

    public virtual void Init(int setSize)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0.8f,1,0.7f,1,0.8f,1);
        transform.localScale = new Vector3((setSize*0.25f+1), transform.localScale.y, transform.localScale.z);
    }
}
