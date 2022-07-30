using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CurveAnimator : MonoBehaviour
{
    [SerializeField] GameObjectEvent phaseEnterEvent;
    [SerializeField] GameObjectEvent phaseExitEvent;
    public List<PhaseEvent> currentPhaseEvents;
    public PhaseEvent defaultEvent;

    public ThirdPersonController body;
    public GameObject objectToAnimate;
    public List<CurveAnimSO> animSet;
    public int indexOfAnimSet = 0;
    public bool endOfAnimChain = false;

    private bool isAnimActive = false;

    public void LoadAnimSet(WeaponSO weapon)
    {
        animSet.Clear();
        foreach(CurveAnimSO caso in weapon.MoveSet)
        {
            animSet.Add(caso);
        }
    }

    private void IncrementAnimSetIndex()
    {
        if (!endOfAnimChain)
        {
            if (indexOfAnimSet < animSet.Count - 1)
            {
                indexOfAnimSet += 1;
            }
            else
            {
                indexOfAnimSet = 0;
            }
            endOfAnimChain = false;
        }
        else
        {
            indexOfAnimSet = 0;
        }
    }


    public void PlayAnimation()
    {
        if (!isAnimActive)
        {
            StartCoroutine(StartAnimating(animSet[indexOfAnimSet]));
        }
    }

    private IEnumerator StartAnimating(CurveAnimSO animSO)
    {
        InitializePhaseData(animSO);

        isAnimActive = true;
        float animLength = animSO.animLength;
        float timeElapsed = 0f;

        while(timeElapsed < animLength)
        {
            float percentComplete = timeElapsed / animLength;

            objectToAnimate.transform.localPosition = EvaluateForPositionVector(percentComplete, animSO);
            objectToAnimate.transform.localEulerAngles = EvaluateForRotationVector(percentComplete, animSO);

            EvaulatePhaseData(percentComplete, animSO);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        objectToAnimate.transform.localPosition = EvaluateForPositionVector(100f, animSO);
        objectToAnimate.transform.localEulerAngles = EvaluateForRotationVector(100f, animSO);

        //EvaulatePhaseData(100, animSO);

        IncrementAnimSetIndex();
        isAnimActive = false;
    }

    private Vector3 EvaluateForPositionVector(float query, CurveAnimSO animSO)
    {
        float posXval = animSO.posX.Evaluate(query);
        float posYval = animSO.posY.Evaluate(query);
        float posZval = animSO.posZ.Evaluate(query);
        return new Vector3(posXval, posYval, posZval);
    }
    private Vector3 EvaluateForRotationVector(float query, CurveAnimSO animSO)
    {
        float posXval = animSO.rotX.Evaluate(query);
        float posYval = animSO.rotY.Evaluate(query);
        float posZval = animSO.rotZ.Evaluate(query);
        return new Vector3(posXval, posYval, posZval);
    }

    private void EvaulatePhaseData(float query, CurveAnimSO animSO)
    {
        if(animSO.phaseIndex < animSO.phaseData.Count)
        {
            if(query > animSO.phaseData[animSO.phaseIndex].phaseConstraints.PhaseStart && !animSO.phaseData[animSO.phaseIndex].hasBeenEntered)
            {
                currentPhaseEvents[0] = animSO.phaseData[animSO.phaseIndex].phaseEvents[0];
                currentPhaseEvents[1] = animSO.phaseData[animSO.phaseIndex].phaseEvents[1];

                phaseEnterEvent.Raise(this.gameObject);

                animSO.phaseData[animSO.phaseIndex].hasBeenEntered = true;
            }

            if(query > animSO.phaseData[animSO.phaseIndex].phaseConstraints.PhaseEnd && !animSO.phaseData[animSO.phaseIndex].hasBeenExited)
            {
                phaseExitEvent.Raise(this.gameObject);

                animSO.phaseData[animSO.phaseIndex].hasBeenExited = true;
                animSO.phaseIndex += 1;
            }

        }
        else
        {
            animSO.phaseIndex = 0;
        }
    }

    public void SetEventsToNone()
    {
        currentPhaseEvents[0] = defaultEvent;
        currentPhaseEvents[1] = defaultEvent;
    }

    private void InitializePhaseData(CurveAnimSO animSo)
    {
        animSo.phaseIndex = 0;

        foreach(PhaseDataSO pd in animSo.phaseData)
        {
            pd.hasBeenEntered = false;
            pd.hasBeenExited = false;
        }
    }

}
