using UnityEngine;
using WaterSortPuzzle.Services;
using WaterSortPuzzle.Services.LoadSceneServices;

namespace WaterSortPuzzle
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private Game _game;

    private void Awake()
    {
      _game = new Game(new SceneLoader(this) ,AllServices.Container);

      DontDestroyOnLoad(this);
    }
  }
}