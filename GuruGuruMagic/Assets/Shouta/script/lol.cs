using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour {

    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
            _rotating = false;
        }
    }

    public bool Enabled;

    [SerializeField]
    private GameObject _target;
    private bool _rotating;
    private float _rot;


	// Use this for initialization
	void Start () {

        _target = null;
        _rotating = false;
        Enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Enabled == false || _target == null)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            print("左ボタンが押されている");
            _rot = _target.transform.eulerAngles.y + GetAngle(Input.mousePosition);
            _rotating = true;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rotating = false;
        }
        if (!_rotating)
            {
                return;
            }

            _target.transform.rotation = Quaternion.Euler (0f, _rot - GetAngle(Input.mousePosition), 0f);
        }
		
	

    private float GetAngle(Vector3 pos)
    {
        var camera = GameObject.FindObjectOfType<Camera>();
        var origin = camera.WorldToScreenPoint(_target.transform.position);

        Vector3 diff = pos - origin;

        var angle = diff.magnitude < Vector3.kEpsilon
                        ? 0.0f
                        : Mathf.Atan2(diff.y, diff.x);

        return angle * Mathf.Rad2Deg;
    }
}
