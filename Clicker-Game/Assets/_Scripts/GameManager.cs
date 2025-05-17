using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }

    private float _score;
    private int _clickPower = 1;
    private int _additionPerSecond;

    private float _multiplayerMeter;
    [SerializeField] private float _multiplayerMeterIncrement = 0.4f;
    [SerializeField] private float _multiplayerMeterDecrement = 0.35f;
    [SerializeField] private float multiplayerThreshHold = 0.96f;
    [SerializeField] private float _multiplayerMeterMax = 2;

    [SerializeField] private MeterUI meterUI;

    public float Score => _score;
    public int ClickPower => _clickPower;

    [SerializeField] private TextMeshProUGUI _scoreTextMesh;
    [SerializeField] private TextMeshProUGUI _velocityTextMesh;
    [SerializeField] private TextMeshProUGUI _clickpowertextMesh;

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
        Clicker.Instance.OnClickerPressed += Clicker_OnClikerPressed;
    }

    private float _idelScoreAdderTimer;
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

        _velocityTextMesh.text = $"${_additionPerSecond} per second";
        _clickpowertextMesh.text = $"${ClickPower} / Click";

        if (_multiplayerMeter > 0)
        {
            _multiplayerMeter -= _multiplayerMeterDecrement * Time.deltaTime;
            if (GetMeterLerp() < 0.7f) _isMultiplayerEnabled = false;
        }
        else
        {
            _multiplayerMeter = 0;
        }

        meterUI.SetImageFill(_multiplayerMeter, _multiplayerMeterMax);
        
    }
    
    private void Clicker_OnClikerPressed()
    { 
        IncreaseScoreBy(_isMultiplayerEnabled ? (int) (ClickPower * _multiplayerMeterMax): ClickPower );
        if (_multiplayerMeter >= _multiplayerMeterMax) return;
        _multiplayerMeter += _multiplayerMeterIncrement;

        if (GetMeterLerp() > multiplayerThreshHold) _isMultiplayerEnabled = true;
    }

    public void IncreaseScoreBy(int amount)
    {
        _score += amount;
        _scoreTextMesh.text = $"${(int)_score}";
    }

    public void IncreaseScoreBy(float amount)
    {
        _score += amount;
        _scoreTextMesh.text = $"${(int)_score}";
    }

    public void DecreaseScoreBy(int amount)
    {
        _score -= amount;
        if (_score < 0) _score = 0;
        _scoreTextMesh.text = $"${(int)_score}";
    }

    public void IncreaseClickPower(int amount)
    {
        _clickPower += amount;
    }

    public void IncreaseIdelSppedBy(int amount)
    {
        _additionPerSecond += amount;
    }

    private float GetMeterLerp()
    {
        return Mathf.InverseLerp(0, _multiplayerMeterMax, _multiplayerMeter);
    }
}
