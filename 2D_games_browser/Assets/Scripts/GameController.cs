using Controller;
using Data;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData _data;
    private Controllers _controllers;
    private void Start()
    {

    }

    private void Awake()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _data);
        _controllers.Initialization();
        _controllers.AwakeExecute();
    }
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.Execute(deltaTime);
    }

    private void LateUpdate()
    {
        var deltaTime = Time.deltaTime;
        _controllers.LateExecute(deltaTime);
    }
    private void FixedUpdate()
    {
        _controllers.FixedExecute();
    }

    private void OnDestroy()
    {
        _controllers.Cleanup();
    }
}