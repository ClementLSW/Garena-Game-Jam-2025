using UnityEngine;

public class ResumeScroll : MonoBehaviour
{
    Vector2 c1Input, c2Input;
    [SerializeField] float scrollSpeed;
    [SerializeField] Renderer resume;

    float minX, maxX, minY, maxY;
    public void SubmitInput(int controllerId, Vector2 inputValue)
    {
        switch (controllerId)
        {
            case 0:
                c1Input = inputValue;
                break;
            case 1:
                c2Input = inputValue;
                break;
        }
    }

    private void Start()
    {
        var vertExtend = Camera.main.orthographicSize;
        var horExtend = vertExtend * Screen.width/Screen.height;

        minX = horExtend - resume.bounds.size.x * 0.5f;
        maxX = resume.bounds.size.x * 0.5f - horExtend;
        minY = vertExtend - resume.bounds.size.y * 0.5f;
        maxY = resume.bounds.size.y * 0.5f - vertExtend;
    }

    private void Update()
    {
        PerformScroll();
    }

    private void LateUpdate()
    {
        transform.position = new(Mathf.Clamp(transform.position.x, minX, maxX),Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }

    void PerformScroll()
    {
        var mediatedInput = c1Input + c2Input;
        Debug.Log(mediatedInput);
        transform.position += (Vector3) mediatedInput * scrollSpeed * Time.deltaTime;
    }
}
