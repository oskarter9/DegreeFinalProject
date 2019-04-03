using UnityEngine;
using UnityEngine.Rendering;

public class TwinCameraController : MonoBehaviour
{
    public RenderTexture initialRT;

    public Camera _activeCamera;
    public Material _activeCameraMat;
    [SerializeField]
    private Camera _hiddenCamera;
    private Material _hiddenCameraMat;

    private float _timeToChangeScene;
    private float currentTime = 4f;
    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GetComponentInParent<Player>().GetComponent<Transform>();
        _playerTransform.gameObject.layer = LayerMask.NameToLayer("UniverseA");
        _activeCameraMat = _activeCamera.GetComponent<PostProcessDepthGrayscale>().mat;
        _timeToChangeScene = _activeCameraMat.GetFloat("_RingPassTimeLength");
        _hiddenCamera.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        _activeCameraMat.SetFloat("_RunRingPass", 0);
        _hiddenCamera.targetTexture = initialRT;
    }

    void Update()
    {
        if (TimeElapsed())
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                currentTime = 0f;
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

        
        _activeCameraMat.SetFloat("_RunRingPass", 0);
        //_hiddenCamera.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        _activeCamera.GetComponent<PostProcessDepthGrayscale>().enabled = true;
    }

    private void ChangeSceneMat()
    {
        _activeCameraMat.SetTexture("_AnotherTex", _hiddenCamera.targetTexture);
        _activeCameraMat.SetFloat("_StartingTime", Time.time);
        _activeCameraMat.SetFloat("_RunRingPass", 1);
        _activeCameraMat.SetFloat("_RingWidth", 0.001f);
    }

    private bool TimeElapsed()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= _timeToChangeScene)
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
