using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MorseGenerator : MonoBehaviour {

    public int CodeLength = 4;

    private readonly Dictionary<char, string> _morseCodes = new Dictionary<char, string>{
        {'a',".-" },
        {'b',"-..." },
        {'c',"-.-." },
        {'d',"-.." },
        {'e',"." },
        {'1',".----" },
        {'2',"..---" },
        {'3',"...--" },
        {'4',"....-" },
        {'5',"....." }
    };

    private readonly char[] _possibleDigits = { 'a', 'b', 'c', 'd', 'e', '1', '2', '3', '4', '5' };

    private Light _morseLight;

    private string _codeToShow;

    private WaitForSeconds _delayMorseFlashDot, _delayMorseFlashDash, _delayBetweenFlashes, _delayBetweenCodeLetters, _delayCodeStart;

    private float _morseFlashDotDuration = 0.5f;
    private float _morseFlashDashDuration = 2.5f;
    private float _timeBetweenFlashes = 1f;
    private float _timeBetweenCodeLetters = 2f;
    private float _timeCodeRestart = 3f;

    // Use this for initialization
    private void Awake() {
        InitializeWaitForSeconds();
        _morseLight = GetComponent<Light>();
        _morseLight.intensity = 0f;
        _codeToShow = FiveDigitsGenerator();
        Debug.Log(_codeToShow);
	}

    private void Start()
    {
        StartCoroutine(FlashMorseCode(_codeToShow));
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
        _morseLight.intensity = 0f;
        Debug.Log("INICIO DE CÓDIGO MORSE");
        yield return _delayCodeStart;

        foreach (char letter in codeToShow)
        {
            string letterToMorse = _morseCodes[letter];

            foreach (char morseDigit in letterToMorse)
            {
                if (morseDigit == '.')
                {
                    _morseLight.intensity = 2f;
                    yield return _delayMorseFlashDot;
                    _morseLight.intensity = 0f;
                    yield return _delayBetweenFlashes;
                }
                else
                {
                    _morseLight.intensity = 2f;
                    yield return _delayMorseFlashDash;
                    _morseLight.intensity = 0f;
                    yield return _delayBetweenFlashes;
                }
            }
            yield return _delayBetweenCodeLetters;
        }
        StartCoroutine(FlashMorseCode(codeToShow));
    }
}
