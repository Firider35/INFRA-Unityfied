using System.Collections;
using UnityEngine;

public class MenuCameraMover : MonoBehaviour
{

    public Transform lerpobject;
    public Transform targetPC;
    public Transform targetTa;
    public Transform targetPr;
    public float lerpspeed = 1f;
    public float lerprotatesp = 1f;

    private bool Move1 = false;
    private bool Move2 = false;
    private bool Move3 = false;
    private bool Move4 = false;

    private Transform target;
    private Quaternion targetR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Move1)
        {
            //lerpobject.position = Vector3.Lerp(lerpobject.position, targetTa.position, Time.deltaTime * lerpspeed);
            //lerpobject.rotation = Quaternion.Lerp(lerpobject.rotation, targetTa.rotation, Time.deltaTime * lerprotatesp);
            target = targetTa;
            targetR = targetTa.rotation;

            StartCoroutine(MoveTo(target.position, targetR));
            Move1 = false;
        }


        if (Move2)
        {
            //lerpobject.position = Vector3.Lerp(lerpobject.position, targetPC.position, Time.deltaTime * lerpspeed);
            //lerpobject.rotation = Quaternion.Lerp(lerpobject.rotation, targetPC.rotation, Time.deltaTime * lerprotatesp);
            target = targetPC;
            targetR = targetPC.rotation;

            StartCoroutine(MoveTo(target.position, targetR));
            Move2 = false;
        }

        if (Move3)
        {
            //lerpobject.position = Vector3.Lerp(lerpobject.position, targetPr.position, Time.deltaTime * lerpspeed);
            //lerpobject.rotation = Quaternion.Lerp(lerpobject.rotation, targetPr.rotation, Time.deltaTime * lerprotatesp);
            target = targetPr;
            targetR = targetPr.rotation;

            StartCoroutine(MoveTo(target.position, targetR));
            Move3 = false;
        }

        if (Move4)
        {
            //lerpobject.position = Vector3.Lerp(lerpobject.position, targetPC.position, Time.deltaTime * lerpspeed);
            //lerpobject.rotation = Quaternion.Lerp(lerpobject.rotation, targetPC.rotation, Time.deltaTime * lerprotatesp);
            target = targetPC;
            targetR = targetPC.rotation;

            StartCoroutine(MoveTo(target.position, targetR));
            Move4 = false;
        }

        /*if ((Vector3.Distance(lerpobject.position, targetTa.position) <= 0.1) && (Quaternion.Angle(lerpobject.rotation, targetTa.rotation) <= 0.1))
        {
            Move1 = false;
        }

        if ((Vector3.Distance(lerpobject.position, targetPC.position) <= 0.1) && (Quaternion.Angle(lerpobject.rotation, targetPC.rotation) <= 0.1))
        {
            Move2 = false;
        }

        if ((Vector3.Distance(lerpobject.position, targetPr.position) <= 0.1) && (Quaternion.Angle(lerpobject.rotation, targetPr.rotation) <= 0.1))
        {
            Move3 = false;
        }

        if ((Vector3.Distance(lerpobject.position, targetPC.position) <= 0.1) && (Quaternion.Angle(lerpobject.rotation, targetPC.rotation) <= 0.1))
        {
            Move4 = false;
        }*/

    }

    public void PcTPr()
    {
        Move3 = true;
    }

    public void PrTPc()
    {
        Move4 = true;
    }

    public void PcTTa()
    {
        Move1 = true;
    }

    public void TaTPc()
    {
        Move2 = true;
    }
    private IEnumerator MoveTo(Vector3 target, Quaternion targetR)
    {
        float elapsed = 0f;
        float duration = 2.5f;

        Vector3 start = lerpobject.position;
        Quaternion startR = lerpobject.rotation;

        while (elapsed < duration)
        {
            lerpobject.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
                yield return null;
            lerpobject.rotation = Quaternion.Slerp(startR, targetR, elapsed / duration);
        }
        lerpobject.position = target;
        lerpobject.rotation = targetR;
    }
}