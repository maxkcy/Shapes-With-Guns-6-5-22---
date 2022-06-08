using UnityEngine;
using UnityEngine.InputSystem;

public class GunDrag : MonoBehaviour
{
    private Vector2 _mPos;
    private Vector2 _offSet;
    private Gun _gun;

    public Gun Gun
    {
        get
        {
            return _gun;
        }
        set 
        {
            _gun = value; 
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        UpdateDrag();
    }

    private void OnLook(InputValue val)
    {
        _mPos = val.Get<Vector2>();
        _mPos = Camera.main.ScreenToWorldPoint(_mPos);
    }

    private void OnClick()
    {
        RaycastHit2D gunHit = Physics2D.Raycast(_mPos, Vector2.zero);
        if (gunHit && gunHit.collider.CompareTag("Gun"))
        {
            Debug.Log("<color=white>GunDrag:</color> Touched a gun " + gunHit.collider.gameObject);
            _gun = gunHit.collider.GetComponent<Gun>();
            switch (_gun.GunState)
            {
                case GunState.Armed:
                    _offSet = (Vector2)gunHit.collider.transform.position - _mPos;
                    _gun.GunState = GunState.GettingDragged;
                    break;

                case GunState.GettingDragged:
                    RaycastHit2D hitWhiledDragged = Physics2D.Raycast(_mPos, Vector2.zero, 0f, LayerMask.GetMask("UI", "Player"));
                    Debug.Log("<color=white>GunDrag:</color> hit a gun that's being dragged");
                    if (hitWhiledDragged)
                    {
                         if (hitWhiledDragged.collider.CompareTag("Player"))
                            {
                                Debug.Log("<color=white>GunDrag:</color> attaching gun to player");
                                _gun.GunState = GunState.Armed;
                                if (_gun.transform.parent != hitWhiledDragged.collider.transform)
                                {
                                    _gun.transform.parent = hitWhiledDragged.collider.transform;
                                }
                                _offSet = new Vector2(0,0);
                                _gun = null;
                            }
                        
                    }
                    else
                    {
                        _gun.transform.parent = null;
                        _gun.GunState = GunState.OnGround;
                        _gun = null;
                    }
                    break;

                case GunState.OnGround:
                    _offSet = (Vector2)gunHit.collider.transform.position - _mPos;
                    _gun.GunState = GunState.GettingDragged;
                    break;

                default:
                    break;
            }
        }
        else
        {
            _gun = null;
        }
    }

    private void UpdateDrag()
    {
        if (_gun?.GunState == GunState.GettingDragged)
        {
            _gun.gameObject.transform.position = _mPos + _offSet;
        }
    }
}