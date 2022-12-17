using UnityEngine;
using WaterSortPuzzle.Data;
using WaterSortPuzzle.Services.PersistentProgress;
using WaterSortPuzzle.Utils;

namespace WaterSortPuzzle.Services.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";
    private readonly IPersistentProgressService _progressService;

    public SaveLoadService(IPersistentProgressService progressService) => 
      _progressService = progressService;

    public void SaveProgress() => 
      PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

    public PlayerProgress LoadProgress() => 
      PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
  }
}