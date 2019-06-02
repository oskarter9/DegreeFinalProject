using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TwinCameraController : MonoBehaviour
{
    //public RenderTexture InitialRenderTexture;

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

    private CommandBuffer _depthHackBuffer;
    [SerializeField]
    private Renderer _depthHackQuad;

    private void Start()
    {
        var rt = new RenderTexture(Screen.width, Screen.height,24);
        rt.format = RenderTextureFormat.ARGBFloat;
        Shader.SetGlobalTexture("_TimeCrackTexture", rt);

        _referencesManager = ReferencesManager.instance;
        _soundsManager = SoundsManager.instance;
        _activeCamera = _referencesManager.CameraSceneA;
        _hiddenCamera = _referencesManager.CameraSceneB;
        _hiddenCamera.targetTexture = rt;
        _playerTransform = _referencesManager.Player.GetComponent<Transform>();
        ChangeLayerRecursively(_playerTransform, "UniverseA");
        ActiveCameraMaterial = _activeCamera.GetComponent<CameraRTCapture>().Mat;
        _timeToChangeScene = ActiveCameraMaterial.GetFloat("_RingPassTimeLength");
        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
    }

    void Update()
    {
        if (TimeElapsed())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                _currentTime = 0f;
                ChangeSceneMat();
                Invoke("SwapCameras", _timeToChangeScene);
            }
        }
    }

    public void SwapCameras()
    {
        SceneARefSounds();
        ChangePlayerLayer();
        _activeCamera.targetTexture = _hiddenCamera.targetTexture;
        _hiddenCamera.targetTexture = null;

        var swapCamera = _activeCamera;
        _activeCamera = _hiddenCamera;
        _hiddenCamera = swapCamera;

        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
        _activeCamera.GetComponent<CameraRTCapture>().enabled = true;
    }

    private void SceneARefSounds()
    {
        if (_currentSceneIndex == 1)
        {
            _referencesManager.DisableReflectionProbes();
            _soundsManager.DisableSceneAAudio();
            _currentSceneIndex = 2;
        }
        else
        {
            _referencesManager.EnableReflectionProbes();
            _soundsManager.EnableSceneAAudio();
            _currentSceneIndex = 1;
        }
    }
    private void ChangeSceneMat()
    {
        ActiveCameraMaterial.SetTexture("_AnotherTex", _hiddenCamera.targetTexture);
        ActiveCameraMaterial.SetFloat("_StartingTime", Time.timeSinceLevelLoad);
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
            ChangeLayerRecursively(_playerTransform, "UniverseB");
        }
        else
        {
            ChangeLayerRecursively(_playerTransform, "UniverseA");
        }
    }

    private void ChangeLayerRecursively(Transform trans, string layerName)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
        {
            ChangeLayerRecursively(child, layerName);
        }
    }
}
