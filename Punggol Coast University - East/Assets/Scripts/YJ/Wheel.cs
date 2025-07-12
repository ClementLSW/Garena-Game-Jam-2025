using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] int wheelId;
    public int WheelId => wheelId;

    [SerializeField] List<WheelControl> wheelControls;
    List<WheelControl> _wheelControlsInternal;
    [SerializeField] List<WheelWaypoint> waypoints;

    public bool allowSubmitAnswer = true;

    private void Start()
    {
        _wheelControlsInternal = new(wheelControls);
        allowSubmitAnswer = true;

        //Initial Setup
        /*foreach (var waypoint in waypoints)
        {
            var randomWheelControl = Random.Range(0, _wheelControlsInternal.Count);
            randomWheelControl = 0;
            _wheelControlsInternal[randomWheelControl].SetWaypoint(waypoint);
            _wheelControlsInternal.RemoveAt(randomWheelControl);
        }*/
    }

    public void Setup()
    {
        foreach (var wheel in FindObjectsByType<Wheel>(FindObjectsSortMode.None))
        {
            foreach (var wheelControlInner in wheel.wheelControls)
            {
                wheelControlInner.allowScroll = true;
                allowSubmitAnswer = true;
                wheelControlInner.answerBoxControl.AnswerUnlock();
            }
        }
    }

    public void MoveNext()
    {
        foreach (var wheelControl in wheelControls)
        {
            wheelControl.MoveToPreviousWaypoint();
        }
    }
    public void MovePrev()
    {
        foreach (var wheelControl in wheelControls)
        {
            wheelControl.MoveToNextWaypoint();
        }
    }

    public void SubmitAnswer()
    {
        if (!allowSubmitAnswer) return;
        foreach (var wheelControl in wheelControls)
        {
            var answer = wheelControl.answerBoxControl;
            if (answer.boxInFocus)
            {
                var isAnswerCorrect = FindAnyObjectByType<QnAManager>().ValidateAnswer(answer.answerText.text);
                Debug.Log($"Answer Validating: {isAnswerCorrect}");
                answer.AnswerLocked(isAnswerCorrect);
                foreach (var wheelControlInner in wheelControls)
                {
                    wheelControlInner.allowScroll = false;
                }

                StartCoroutine(Wait3SecondsAndCheckAnswer());

                IEnumerator Wait3SecondsAndCheckAnswer()
                {
                    if (isAnswerCorrect)
                    {
                        switch (wheelId)
                        {
                            case 0:
                                //Player P1 Animation
                                FindObjectsByType<Player>(FindObjectsSortMode.None).Where(x => x.playerId == wheelId).FirstOrDefault().GetComponent<Animator>().Play("SlamAnswer");
                                FindObjectsByType<Player>(FindObjectsSortMode.None).Where(x => x.playerId != wheelId).FirstOrDefault().GetComponent<Animator>().Play("Slam");

                                //Lock P2
                                foreach (var wheel in FindObjectsByType<Wheel>(FindObjectsSortMode.None))
                                {
                                    foreach (var wheelControlInner in wheel.wheelControls)
                                    {
                                        wheelControlInner.allowScroll = false;
                                        allowSubmitAnswer = false;
                                    }

                                }
                                GameManager.Instance.p1Score++;
                                if (GameManager.Instance.p1Score >= 3)
                                {
                                    //Reset scores;
                                    GameManager.Instance.p1Score = 0;
                                    GameManager.Instance.p2Score = 0;
                                    GameManager.Instance.p1Sidekick++;
                                    yield return new WaitForSeconds(1.5f);
                                    //ResumeGenerator.Instance.GenerateData();
                                    GameManager.Instance.SwapState(GameManager.State.Resume);
                                    yield break;
                                }



                                Debug.Log($"Countdown start 3 seconds correct answer");
                                yield return new WaitForSeconds(1.5f);
                                Debug.Log($"Countdown end 3 seconds correct answer");
                                foreach (var player in FindObjectsByType<Player>(FindObjectsSortMode.None))
                                {
                                    player.GetComponent<Animator>().Play("Idle");
                                }
                                FindAnyObjectByType<QnAManager>().Populate();
                                foreach (var wheel in FindObjectsByType<Wheel>(FindObjectsSortMode.None))
                                {
                                    foreach (var wheelControlInner in wheel.wheelControls)
                                    {
                                        wheelControlInner.allowScroll = true;
                                        allowSubmitAnswer = true;
                                    }

                                }
                                answer.AnswerUnlock();
                                break;
                            case 1:
                                //Player P2 Animation
                                FindObjectsByType<Player>(FindObjectsSortMode.None).Where(x => x.playerId == wheelId).FirstOrDefault().GetComponent<Animator>().Play("SlamAnswer");
                                FindObjectsByType<Player>(FindObjectsSortMode.None).Where(x => x.playerId != wheelId).FirstOrDefault().GetComponent<Animator>().Play("Slam");

                                //Lock P1
                                foreach (var wheel in FindObjectsByType<Wheel>(FindObjectsSortMode.None))
                                {
                                    foreach (var wheelControlInner in wheel.wheelControls)
                                    {
                                        wheelControlInner.allowScroll = false;
                                        allowSubmitAnswer = false;
                                    }

                                }
                                GameManager.Instance.p2Score++;
                                if (GameManager.Instance.p2Score >= 3)
                                {
                                    GameManager.Instance.p1Score = 0;
                                    GameManager.Instance.p2Score = 0;
                                    GameManager.Instance.p2Sidekick++;
                                    yield return new WaitForSeconds(1.5f);
                                    //ResumeGenerator.Instance.GenerateData();
                                    GameManager.Instance.SwapState(GameManager.State.Resume);
                                    yield break;
                                }



                                Debug.Log($"Countdown start 3 seconds correct answer");
                                yield return new WaitForSeconds(1.5f);
                                Debug.Log($"Countdown end 3 seconds correct answer");
                                foreach (var player in FindObjectsByType<Player>(FindObjectsSortMode.None))
                                {
                                    player.GetComponent<Animator>().Play("Idle");
                                }
                                FindAnyObjectByType<QnAManager>().Populate();
                                foreach (var wheel in FindObjectsByType<Wheel>(FindObjectsSortMode.None))
                                {
                                    foreach (var wheelControlInner in wheel.wheelControls)
                                    {
                                        wheelControlInner.allowScroll = true;
                                        allowSubmitAnswer = true;
                                    }

                                }
                                answer.AnswerUnlock();
                                break;
                        }

                        //Reset all
                    }
                    else
                    {
                        Debug.Log($"Countdown start 3 seconds incorrect answer");
                        yield return new WaitForSeconds(1.5f);
                        Debug.Log($"Countdown end 3 seconds incorrect answer");
                        foreach (var wheelControlInner in wheelControls)
                        {
                            wheelControlInner.allowScroll = true;
                        }
                        answer.AnswerUnlock();
                    }

                }
            }
        }
    }
}
