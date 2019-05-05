using UnityEngine;
using UnityEngine.SceneManagement;

public class TwinCameraController : MonoBehaviour
{
    public RenderTexture InitialRenderTexture;

    public Material ActiveCameraMaterial;

    private ReferencesManager _referencesManager;
    private SoundsManager _soundsManager;

    private Camera _activeCamera;
    private Camera _hiddenCamera;
    private Material _hiddenCameraMat;
    private int _currentSceneIndex = 1;

    private float _timeToChangeScene;
    private float _currentTime = 4f;

    private Transform _playerTransform;

    private void Start()
    {
        _referencesManager = ReferencesManager.instance;
        _soundsManager = SoundsManager.instance;
        _activeCamera = _referencesManager.CameraSceneA;
        _hiddenCamera = _referencesManager.CameraSceneB;
        _playerTransform = _referencesManager.Player.GetComponent<Transform>();
        ActiveCameraMaterial = _activeCamera.GetComponent<PostProcessDepthGrayscale>().Mat;
        _playerTransform.gameObject.layer = LayerMask.NameToLayer("UniverseA");
        _timeToChangeScene = ActiveCameraMaterial.GetFloat("_RingPassTimeLength");
        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
    }

    void Update()
    {
        if (TimeElapsed())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_currentSceneIndex == 1)
                {
                    _soundsManager.DisableSceneAAudio();
                    _currentSceneIndex = 2;
                }
                else
                {
                    _soundsManager.EnableSceneAAudio();
                    _currentSceneIndex = 1;
                }
                _currentTime = 0f;
                ChangeSceneMat();
                Invoke("SwapCameras", _timeToChangeScene);
            }
        }

    }

    public void SwapCameras()
    {
        ChangePlayerLayer();
        _activeCamera.targetTexture = _hiddenCamera.targetTexture;
        _hiddenCamera.targetTexture = null;

        var swapCamera = _activeCamera;
        _activeCamera = _hiddenCamera;
        _hiddenCamera = swapCamera;

        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
        _activeCamera.GetComponent<PostProcessDepthGrayscale>().enabled = true;
    }

    private void ChangeSceneMat()
    {
        ActiveCameraMaterial.SetTexture("_AnotherTex", _hiddenCamera.targetTexture);
        ActiveCameraMaterial.SetFloat("_StartingTime", Time.time);
        ActiveCameraMaterial.SetFloat("_RunRingPass", 1);
        ActiveCameraMaterial.SetFloat("_RingWidth", 0.01f);
    }

    private bool TimeElapsed()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _timeToChangeScene)
        {
            return true;
        }
        return false;
    }

    private void ChangePlayerLayer()
    {
        if(_playerTransform.gameObject.layer == LayerMask.NameToLayer("UniverseA")){
            _playerTransform.gameObject.layer = LayerMask.NameToLayer("UniverseB");
        }
        else
        {
            _playerTransform.gameObject.layer = LayerMask.NameToLayer("UniverseA");
        }
    }
}
