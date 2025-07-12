using System.Collections;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    public float moveDistance = 1.5f;  // Distance to move on Y
    public float moveSpeed = 1f;      // Units per second — increase this for faster motion
    private bool isMoving = false;

    public AnswerBoxControl answerBoxControl;

    public Vector3 BigScale;
    public Vector3 MediumScale;
    public Vector3 SmallScale;

    public float scaleSpeed = 5f;
    public float duration = 0.01f; //for scale lerp

    [SerializeField] WheelWaypoint waypoint;

    SpriteRenderer spriteRenderer;
    Canvas canvas;

    public bool allowScroll = true;
    private void Start()
    {
        answerBoxControl = GetComponent<AnswerBoxControl>();
        BigScale = gameObject.transform.localScale;
        MediumScale = BigScale * 0.8f;
        SmallScale = BigScale * 0.4f;

        //InitialScale(gameObject.GetComponent<AnswerBoxControl>().boxPosition);
        spriteRenderer = GetComponent<SpriteRenderer>();
        canvas = GetComponentInChildren<Canvas>();
        answerBoxControl.boxInFocus = waypoint.isSelectedWaypoint;
        spriteRenderer.sortingOrder = waypoint.targetSortingOrder;
        canvas.sortingOrder = waypoint.targetSortingOrder + 1;
    }

    public void ClearWaypoint()
    {
        waypoint = null;
    }

    public void SetWaypoint(WheelWaypoint waypoint)
    {
        this.waypoint = waypoint;
    }

    public void MoveToPreviousWaypoint()
    {
        if (!allowScroll) return;
        if (waypoint == null) return;
        Debug.Log($"{gameObject.name} moving to {waypoint.PrevWaypoint}");
        answerBoxControl.boxInFocus = waypoint.PrevWaypoint.isSelectedWaypoint;
        spriteRenderer.sortingOrder = waypoint.PrevWaypoint.targetSortingOrder;
        canvas.sortingOrder = waypoint.PrevWaypoint.targetSortingOrder + 1;
        waypoint = waypoint.PrevWaypoint;
    }

    public void MoveToNextWaypoint()
    {
        if (!allowScroll) return;
        if (waypoint == null) return;
        Debug.Log($"{gameObject.name} moving to {waypoint.NextWaypoint}");
        answerBoxControl.boxInFocus = waypoint.NextWaypoint.isSelectedWaypoint;
        spriteRenderer.sortingOrder = waypoint.NextWaypoint.targetSortingOrder;
        canvas.sortingOrder = waypoint.NextWaypoint.targetSortingOrder + 1;
        waypoint = waypoint.NextWaypoint;
    }
    void Update()
    {
        //transform.localScale = Vector3.zero;
        if (waypoint == null) return;
        /*transform.position = waypoint.transform.localPosition;
        transform.localScale = waypoint.transform.localScale;*/
        transform.position = Vector3.Lerp(transform.position, waypoint.transform.position, 10 * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, waypoint.transform.localScale, 10 * Time.deltaTime);
        /* Debug.Log($"ismoving: {isMoving}");
         if (!isMoving)
         {
             if (Input.GetKeyDown(KeyCode.S))
             {
                 StartCoroutine(MoveToY(transform.position.y - moveDistance));
                 AdjustScaleDown(gameObject.GetComponent<AnswerBoxControl>().boxPosition);
                 gameObject.GetComponent<AnswerBoxControl>().boxPosition++;
                 Debug.Log("Next box");
             }
             else if (Input.GetKeyDown(KeyCode.W))
             {
                 StartCoroutine(MoveToY(transform.position.y + moveDistance));
                 AdjustScaleUp(gameObject.GetComponent<AnswerBoxControl>().boxPosition);
                 gameObject.GetComponent<AnswerBoxControl>().boxPosition--;
                 Debug.Log("Prev box");
             }
         }*/
    }

    public void MoveNext()
    {
        /*if (!isMoving)
        {
            if (answerBoxControl.boxPosition == 0)
            {
                StartCoroutine(MoveToY(transform.position.y + 5 * moveDistance));
                AdjustScaleDown(answerBoxControl.boxPosition);
                answerBoxControl.boxPosition = totalBoxes;
            }
            else
            {
                StartCoroutine(MoveToY(transform.position.y - moveDistance));
                AdjustScaleDown(answerBoxControl.boxPosition);
                answerBoxControl.boxPosition++;
            }
            Debug.Log("Next box");
        }*/
    }

    public void MovePrev()
    {
        /*if (!isMoving)
        {
            if (answerBoxControl.boxPosition + 1 == totalBoxes)
            {
                StartCoroutine(MoveToY(transform.position.y - 5 * moveDistance));
                AdjustScaleUp(answerBoxControl.boxPosition);
                answerBoxControl.boxPosition = 0;
            }
            else
            {
                StartCoroutine(MoveToY(transform.position.y + moveDistance));
                AdjustScaleUp(answerBoxControl.boxPosition);
                answerBoxControl.boxPosition--;
            }
            Debug.Log("Prev box");
        }*/
    }

    private IEnumerator MoveToY(float targetY)
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, targetY, startPos.z);

        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            yield return null;
        }

        transform.position = targetPos; // Snap to final position
        isMoving = false;
    }

    public void AdjustScaleDown(int boxPosition)
    {
        if (boxPosition == 1 || boxPosition == 3)
        {
            StartCoroutine(LerpScale(MediumScale));
        }
        if (boxPosition == 2)
        {
            StartCoroutine(LerpScale(BigScale));
        }
        if (boxPosition == 4)
        {
            StartCoroutine(LerpScale(SmallScale));
        }
    }

    public void AdjustScaleUp(int boxPosition)
    {
        if (boxPosition == 3 || boxPosition == 5)
        {
            StartCoroutine(LerpScale(MediumScale));
        }
        if (boxPosition == 4)
        {
            StartCoroutine(LerpScale(BigScale));
        }
        if (boxPosition == 2)
        {
            StartCoroutine(LerpScale(SmallScale));
        }
    }

    public void InitialScale(int boxPosition)
    {
        if (boxPosition == 2 || boxPosition == 4)
        {
            StartCoroutine(LerpScale(MediumScale));
        }

        if (boxPosition == 1 || boxPosition == 5)
        {
            StartCoroutine(LerpScale(SmallScale));
        }
    }

    public IEnumerator LerpScale(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
            yield return null;
        }

        transform.localScale = targetScale; // Snap to final
    }
}