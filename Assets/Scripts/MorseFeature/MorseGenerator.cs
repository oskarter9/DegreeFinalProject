using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MorseGenerator : MonoBehaviour {

    public int CodeLength = 4;
    public string CodeToShow;

    private readonly Dictionary<char, string> _morseCodes = new Dictionary<char, string>{
        {'a',".-" },
        {'b',"-..." },
        {'c',"-.-." },
        {'d',"-.." },
        {'1',".----" },
        {'2',"..---" },
        {'3',"...--" },
        {'4',"....-" },
    };

    private readonly char[] _possibleDigits = { 'a', 'b', 'c', 'd', '1', '2', '3', '4'};

    private Light _morseLight;
    private Material _objectEmissiveMaterial;

    private WaitForSeconds _delayMorseFlashDot, _delayMorseFlashDash, _delayBetweenFlashes, _delayBetweenCodeLetters, _delayCodeStart;

    private float _morseFlashDotDuration = 0.5f;
    private float _morseFlashDashDuration = 2.5f;
    private float _timeBetweenFlashes = 1f;
    private float _timeBetweenCodeLetters = 2f;
    private float _timeCodeRestart = 3f;

    // Use this for initialization
    private void Awake() {
        if (GetComponent<MeshRenderer>())
        {
            _objectEmissiveMaterial = GetComponent<MeshRenderer>().material;
        }
        InitializeWaitForSeconds();
        _morseLight = GetComponentInChildren<Light>();
        _morseLight.intensity = 0f;
        CodeToShow = FiveDigitsGenerator();
        Debug.Log(CodeToShow);
	}

    private void Start()
    {
        StartCoroutine(FlashMorseCode(CodeToShow));
    }

    private string FiveDigitsGenerator()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < CodeLength; i++)
        {
            int rand = Random.Range(0, _possibleDigits.Length);
            sb.Append(_possibleDigits[rand]);
        }

        return sb.ToString();
    }

    private void InitializeWaitForSeconds()
    {
        _delayMorseFlashDot = new WaitForSeconds(_morseFlashDotDuration);
        _delayMorseFlashDash = new WaitForSeconds(_morseFlashDashDuration);
        _delayBetweenFlashes = new WaitForSeconds(_timeBetweenFlashes);
        _delayBetweenCodeLetters = new WaitForSeconds(_timeBetweenCodeLetters);
        _delayCodeStart = new WaitForSeconds(_timeCodeRestart);
    }

    private IEnumerator FlashMorseCode(string codeToShow)
    {
        TurnOffLight();
        Debug.Log("INICIO DE CÓDIGO MORSE");
        yield return _delayCodeStart;

        foreach (char letter in codeToShow)
        {
            string letterToMorse = _morseCodes[letter];

            foreach (char morseDigit in letterToMorse)
            {
                if (morseDigit == '.')
                {
                    TurnOnLight();
                    yield return _delayMorseFlashDot;
                    TurnOffLight();
                    yield return _delayBetweenFlashes;
                }
                else
                {
                    TurnOnLight();
                    yield return _delayMorseFlashDash;
                    TurnOffLight();
                    yield return _delayBetweenFlashes;
                }
            }
            yield return _delayBetweenCodeLetters;
        }
        StartCoroutine(FlashMorseCode(codeToShow));
    }

    private void TurnOnLight()
    {
        _morseLight.intensity = 1f;
        if (_objectEmissiveMaterial != null)
        {
            _objectEmissiveMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void TurnOffLight()
    {
        _morseLight.intensity = 0f;
        if (_objectEmissiveMaterial != null)
        {
            _objectEmissiveMaterial.DisableKeyword("_EMISSION");
        }
    }
}
