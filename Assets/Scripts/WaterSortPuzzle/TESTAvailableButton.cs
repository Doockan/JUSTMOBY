using UnityEngine;
using UnityEngine.UI;
using WaterSortPuzzle.Data;
using WaterSortPuzzle.Services;
using WaterSortPuzzle.Services.LoadSceneServices;
using WaterSortPuzzle.Services.PersistentProgress;
using WaterSortPuzzle.Services.SaveLoad;

namespace WaterSortPuzzle
{
  public class TESTAvailableButton : MonoBehaviour
  {
    private IPersistentProgressService _progressService;
    private ILoadGameSceneService _loadGameSceneService;
    private ILoadMenuService _loadMenuService;
    private ISaveLoadService _saveLoadService;

    private void Start()
    {
      var services = AllServices.Container;
      _progressService = services.Single<IPersistentProgressService>();
      _loadGameSceneService = services.Single<ILoadGameSceneService>();
      _loadMenuService = services.Single<ILoadMenuService>();
      _saveLoadService = services.Single<ISaveLoadService>();


      var button = GetComponent<Button>();
      button.onClick.AddListener(AvailableLevel);
    }

    private void AvailableLevel()
    {
      _progressService.Progress.levelStatus.levels[_loadGameSceneService.CurrentScene - 1] = Availability.Passed;
      if(_loadGameSceneService.CurrentScene != 20)
      {
        if (_progressService.Progress.levelStatus.levels[_loadGameSceneService.CurrentScene] == Availability.NotAvailable)
          _progressService.Progress.levelStatus.levels[_loadGameSceneService.CurrentScene] = Availability.Available;
      }
      _saveLoadService.SaveProgress();
      _loadMenuService.LoadMenuScene();
    }
  }
}