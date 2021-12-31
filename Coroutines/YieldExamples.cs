using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldExamples : MonoBehaviour
{
    private WaitForSeconds wait = new WaitForSeconds(1f);

    IEnumerator IllWaitForYou()
    {
        yield return new WaitForSeconds(3.14f);
    }

    IEnumerator WaitsOneFrame()
    {
        //do stuff
        yield return null;//waits one frame
        //do stuff
        yield return null;//waits another frame
        //do stuff
    }

    IEnumerator AllDone()
    {
        //stops the coroutine
        yield break;
    }

    private int playerScore;

    private bool PlayerScoreCompare()
    {
        return playerScore > 100;
    }

    IEnumerator WaitUntilTrue()
    {
        yield return new WaitUntil(() => PlayerScoreCompare());
    }

    IEnumerator WaitWhileTrue()
    {
        yield return new WaitWhile(() => PlayerScoreCompare());
    }

    IEnumerator IWantToGoLast()
    {
        //waits until other bits are done
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ProbablyPhysicsStuff()
    {
        yield return new WaitForFixedUpdate();
        //physics stuff...?
    }

    IEnumerator KeepingItReal()
    {
        yield return new WaitForSecondsRealtime(2f);
    }
}
