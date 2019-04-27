using UnityEngine;
using UnityEngine.SceneManagement;

public class TwinCameraController : MonoBehaviour
{
    public RenderTexture InitialRenderTexture;

    public Camera ActiveCamera;
    public Material ActiveCameraMaterial;

    [SerializeField]
    private Camera _hiddenCamera;
    private Material _hiddenCameraMat;
    private int _currentSceneIndex = 1;

    private float _timeToChangeScene;
    private float _currentTime = 4f;

    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GetComponentInParent<Player>().GetComponent<Transform>();
        ActiveCameraMaterial = ActiveCamera.GetComponent<PostProcessDepthGrayscale>().Mat;
        _playerTransform.gameObject.layer = LayerMask.NameToLayer("UniverseA");
        _timeToChangeScene = ActiveCameraMaterial.GetFloat("_RingPassTimeLength");
        _hiddenCamera.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
        _hiddenCamera.targetTexture = InitialRenderTexture;
    }

    void Update()
    {
        if (TimeElapsed())
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                /*if(_currentSceneIndex == 1)
                {
                    _currentSceneIndex = 2;
                    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_currentSceneIndex));
                }
                else
                {
                    _currentSceneIndex = 1;
                    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_currentSceneIndex));
                }*/
                _currentTime = 0f;
                //LightmapSettings.lightmaps = new LightmapData[0];
                
                //LightmapSettings.lightmaps = ReferencesManager.instance.POneLighmapSwitch._sceneBLightMaps;
                ChangeSceneMat();
                Invoke("SwapCameras", _timeToChangeScene);
            }
        }

    }

    public void SwapCameras()
    {
        ChangePlayerLayer();
        ActiveCamera.targetTexture = _hiddenCamera.targetTexture;
        _hiddenCamera.targetTexture = null;

        var swapCamera = ActiveCamera;
        ActiveCamera = _hiddenCamera;
        _hiddenCamera = swapCamera;

        ActiveCameraMaterial.SetFloat("_RunRingPass", 0);
        ActiveCamera.GetComponent<PostProcessDepthGrayscale>().enabled = true;
    }

    private void ChangeSceneMat()
    {
        ActiveCameraMaterial.SetTexture("_AnotherTex", _hiddenCamera.targetTexture);
        ActiveCameraMaterial.SetFloat("_StartingTime", Time.time);
        ActiveCameraMaterial.SetFloat("_RunRingPass", 1);
        ActiveCameraMaterial.SetFloat("_RingWidth", 0.001f);
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
