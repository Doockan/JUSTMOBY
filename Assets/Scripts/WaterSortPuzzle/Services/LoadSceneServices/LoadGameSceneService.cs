using System.Collections.Generic;
using WaterSortPuzzle.Data;
using WaterSortPuzzle.Models;
using WaterSortPuzzle.Services.Factory;
using WaterSortPuzzle.Services.PersistentProgress;

namespace WaterSortPuzzle.Services.LoadSceneServices
{
  public class LoadGameSceneService : ILoadGameSceneService
  {
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactoryService _factory;
    private readonly IPersistentProgressService _progressService;
    private readonly IMixFlasksService _mixFlasksService;
    private readonly IPlayerPourService _playerPourService;

    public int CurrentScene { get; private set; }

    public LoadGameSceneService(SceneLoader sceneLoader, IGameFactoryService factory,
      IPersistentProgressService progressService, IMixFlasksService mixService, IPlayerPourService playerPourService)
    {
      _sceneLoader = sceneLoader;
      _factory = factory;
      _progressService = progressService;
      _mixFlasksService = mixService;
      _playerPourService = playerPourService;
    }

    public void LoadLevel(int levelNum)
    {
      if (LevelIsNotAvailable(levelNum))
        return;
      CurrentScene = levelNum;
      _sceneLoader.Load("GameScene", InitializationGameBoard);
    }

    private void InitializationGameBoard()
    {
      List<Flask> flasks = _mixFlasksService.CreteFlasks(CurrentScene);
      _factory.SetCamera();
      _factory.InitializeFlasks(flasks, SubscribePlayer);
    }

    private void SubscribePlayer() => 
      _playerPourService.SubscribeAllFlask();

    private bool LevelIsNotAvailable(int levelNum) => 
      _progressService.Progress.levelStatus.levels[levelNum - 1] == Availability.NotAvailable;
  }
}