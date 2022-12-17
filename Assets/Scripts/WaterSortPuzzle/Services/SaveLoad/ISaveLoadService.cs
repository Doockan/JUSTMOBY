using WaterSortPuzzle.Data;

namespace WaterSortPuzzle.Services.SaveLoad
{
  public interface ISaveLoadService : IService
  {
    void SaveProgress();
    PlayerProgress LoadProgress();
  }
}