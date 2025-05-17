using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }
    private float _score;
    private int _clickPower = 1;
    private int _additionPerSecond;

    private float _multiplayerMeter;
    [SerializeField] private float multiplayerMeterIncrement = 0.4f;
    [SerializeField] private float multiplayerMeterDecrement = 0.35f;
    [SerializeField] private float multiplayerThreshHold = 0.96f;
    [SerializeField] private float multiplayerMeterMax = 2;

    [SerializeField] private MeterUI meterUI;

    public float Score => _score;
    public int ClickPower => _clickPower;

    [SerializeField] private TextMeshProUGUI scoreTextMesh;
    [SerializeField] private TextMeshProUGUI velocityTextMesh;
    [SerializeField] private TextMeshProUGUI clickPowerTextMesh;

    private bool _isMultiplayerEnabled;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _scoreAnimator = scoreTextMesh.gameObject.GetComponent<Animator>();
        Clicker.Instance.OnClickerPressed += Clicker_OnClickerPressed;
    }

    private float _idelScoreAdderTimer;
    private Animator _scoreAnimator;

    private void Update()
    {
        /*if(_idelScoreAdderTimer < 1)
        {
            _idelScoreAdderTimer += Time.deltaTime;
        }
        else
        {
            _idelScoreAdderTimer = 0;
            IncreaseScoreBy(_additionPerSecond);
        }*/

        IncreaseScoreBy(_additionPerSecond * Time.deltaTime);

        velocityTextMesh.text = $"${_additionPerSecond} per second";
        clickPowerTextMesh.text = $"${ClickPower} / Click";

        if (_multiplayerMeter > 0)
        {
            _multiplayerMeter -= multiplayerMeterDecrement * Time.deltaTime;
            if (GetMeterLerp() < 0.7f) _isMultiplayerEnabled = false;
        }
        else
        {
            _multiplayerMeter = 0;
        }

        meterUI.SetImageFill(_multiplayerMeter, multiplayerMeterMax);
        
    }
    
    private void Clicker_OnClickerPressed()
    { 
        IncreaseScoreBy(_isMultiplayerEnabled ? (int) (ClickPower * multiplayerMeterMax): ClickPower );
        if (_multiplayerMeter >= multiplayerMeterMax) return;
        _multiplayerMeter += multiplayerMeterIncrement;

        if (GetMeterLerp() > multiplayerThreshHold) _isMultiplayerEnabled = true;
    }

    public void IncreaseScoreBy(int amount)
    {
        Debug.Log("IncreaseScoreBy1");
        _score += amount;
        scoreTextMesh.text = $"${(int)_score}";
        _scoreAnimator.CrossFadeInFixedTime("ScoreIncrease", 0.1f, 0);
    }

    public void IncreaseScoreBy(float amount)
    {
        //Debug.Log("IncreaseScoreBy2");
        _score += amount;
        scoreTextMesh.text = $"${(int)_score}";
        //_scoreAnimator.CrossFade("ScoreIncrease", 0.1f, 0);
    }

    public void DecreaseScoreBy(int amount)
    {
        Debug.Log("DecreaseScoreBy1");
        _score -= amount;
        if (_score < 0) _score = 0;
        scoreTextMesh.text = $"${(int)_score}";
        _scoreAnimator.CrossFadeInFixedTime("ScoreDecrease", 0.1f, 0);
    }

    public void IncreaseClickPower(int amount)
    {
        _clickPower += amount;
    }

    public void IncreaseIdelSpeedBy(int amount)
    {
        _additionPerSecond += amount;
    }

    private float GetMeterLerp()
    {
        return Mathf.InverseLerp(0, multiplayerMeterMax, _multiplayerMeter);
    }
    
    public bool IsMultiplayerEnabled => _isMultiplayerEnabled;
}
