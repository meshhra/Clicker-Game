using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int _score;
    private int _clickPower = 1;
    private int _additionPerSecond;

    public int Score => _score;
    public int ClickPower => _clickPower;

    [SerializeField] private TextMeshProUGUI _scoreTextMesh;
    [SerializeField] private TextMeshProUGUI _velocityTextMesh;
    [SerializeField] private TextMeshProUGUI _clickpowertextMesh;

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
        if(_idelScoreAdderTimer < 1)
        {
            _idelScoreAdderTimer += Time.deltaTime;
        }
        else
        {
            _idelScoreAdderTimer = 0;
            IncreaseScoreBy(_additionPerSecond);
        }
        _velocityTextMesh.text = $"${_additionPerSecond} per second";
        _clickpowertextMesh.text = $"${ClickPower} / Click";
    }

    private void Clicker_OnClikerPressed()
    { 
        IncreaseScoreBy(ClickPower);
    }

    public void IncreaseScoreBy(int amount)
    {
        _score += amount;
        _scoreTextMesh.text = $"${_score}";
    }

    public void DecreaseScoreBy(int amount)
    {
        _score -= amount;
        if (_score < 0) _score = 0;
        _scoreTextMesh.text = $"${Score}";
    }

    public void IncreaseClickPower(int amount)
    {
        _clickPower += amount;
    }

    public void IncreaseidelSppedBy(int amount)
    {
        _additionPerSecond += amount;
    }
}
