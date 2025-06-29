using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum State {
        NotReady,
        Ready,
        Resume,
        Date,
        End
    }
    public Scene currentScene;
    public State currentState { get; private set; } = State.NotReady;

    #region SingletonPattern
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Make this persistent
        }
        //Debug
        ResumeGenerator.Instance.GenerateData();
        CurrentQuestionSet = QuestionInstance.Instance.GenerateAllQuestions();
        SwapState(State.Date); // Initialize to NotReady state
    }
    #endregion

    #region SceneLoading

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene currentScene, LoadSceneMode mode)
    {

    }

    #endregion

    public Queue<QuestionInstance> CurrentQuestionSet;

    [SerializeField] GameObject mainMenu, resumeMinigame, dateMinigame;
    [SerializeField] QnAManager qnaManager;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapState(State state)
    {
        switch(state)
        {
            case State.NotReady:
                // Default Landing Page State
                break;
            case State.Ready:
                // Call when both players are ready
                HideEverything();
                SwapState(State.Resume);
                break;
            case State.Resume:
                ResumeGenerator.Instance.GenerateData();
                CurrentQuestionSet = QuestionInstance.Instance.GenerateAllQuestions();

                resumeMinigame.SetActive(true);
                Player.FindScrollController();

                //DONE:YUNJING Show Resume
                break;
            case State.Date:
                qnaManager.Populate();
                //TODO:YUNJING Handle Date state
                break;
            case State.End:
                //TODO:YUNJING Handle End state
                break;
            default:
                Debug.LogWarning("Unknown state: " + state);
                break;
        }

        currentState = state;
    }

    void HideEverything()
    {
        mainMenu.SetActive(false);
        resumeMinigame.SetActive(false);
        dateMinigame.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
