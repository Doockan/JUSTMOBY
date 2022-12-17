using WaterSortPuzzle.Data;
using WaterSortPuzzle.Services.Factory;
using WaterSortPuzzle.Services.PersistentProgress;
using WaterSortPuzzle.Services.SaveLoad;

namespace WaterSortPuzzle.Services.LoadSceneServices
{
  public class LoadMenuService : ILoadMenuService
  {
    private const string MenuScene = "MenuScene";
    private const int MaxLevels = 20;

    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactoryService _factory;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadMenuService(SceneLoader sceneLoader, IGameFactoryService factory,
      IPersistentProgressService progressService, ISaveLoadService saveLoadService)
    {
      _sceneLoader = sceneLoader;
      _factory = factory;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
      
      LoadMenuScene();
    }

    public void LoadMenuScene() => 
      _sceneLoader.Load(MenuScene, onLoaded: LoadUi);

    private void LoadUi()
    {
      _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
      _factory.CreateUIRoot();
      _factory.CreateLevelChoiceWindow();
    }

    private PlayerProgress NewProgress()
    {
      var progress = new PlayerProgress();
      for (int i = 0; i < MaxLevels; i++)
        progress.levelStatus.levels.Add(i == 0 ? Availability.Available : Availability.NotAvailable);

      return progress;
    }
  }
}