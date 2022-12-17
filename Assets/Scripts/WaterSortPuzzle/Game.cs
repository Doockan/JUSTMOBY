using WaterSortPuzzle.Data;
using WaterSortPuzzle.Services;
using WaterSortPuzzle.Services.Factory;
using WaterSortPuzzle.Services.LoadSceneServices;
using WaterSortPuzzle.Services.PersistentProgress;
using WaterSortPuzzle.Services.SaveLoad;

namespace WaterSortPuzzle
{
  public class Game
  {
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public Game(SceneLoader sceneLoader ,AllServices services)
    {
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices();
    }

    private void RegisterServices()
    {
      RegisterStaticData();
      
      _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
      _services.RegisterSingle<IAnimationService>(new AnimationService());
      _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>()));
      _services.RegisterSingle<IMixFlasksService>(new MixFlasksService(_services.Single<IStaticDataService>()));
      _services.RegisterSingle<IGameFactoryService>(new GameFactory(_services.Single<IPersistentProgressService>()));

      _services.RegisterSingle<ILoadMenuService>(new LoadMenuService(_sceneLoader,
        _services.Single<IGameFactoryService>(), 
        _services.Single<IPersistentProgressService>(), 
        _services.Single<ISaveLoadService>()));

      _services.RegisterSingle<IPlayerPourService>(new PlayerPourService(_services.Single<IGameFactoryService>(),
        _services.Single<IAnimationService>()));

      _services.RegisterSingle<ILoadGameSceneService>(new LoadGameSceneService(_sceneLoader,
        _services.Single<IGameFactoryService>(), 
        _services.Single<IPersistentProgressService>(),
        _services.Single<IMixFlasksService>(),
        _services.Single<IPlayerPourService>()));
    }

    private void RegisterStaticData()
    {
      var staticData = new StaticDataService();
      staticData.LoadData();
      _services.RegisterSingle<IStaticDataService>(staticData);
    }
  }
}