using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSetUp : MonoBehaviour
{

    GameObject _player, _camera;
    // Use this for initialization
    void Start () {
        _player = Instantiate((GameObject)Resources.Load("Archer"), Vector3.zero, Quaternion.identity);
        _camera = Instantiate((GameObject)Resources.Load("Camera"), new Vector3(0, 15, -20), Quaternion.identity);
        if (_player == null || _camera == null) return;

        _player.GetComponent<CharacterControllerLogic>().Activate(_camera.GetComponentInChildren<ThirdPersonCamera>());
        _camera.GetComponentInChildren<ThirdPersonCamera>().Activate(_player);
        Thread.Sleep(2000);
        Destroy(this.gameObject);
	}
}
