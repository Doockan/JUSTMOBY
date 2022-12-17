using WaterSortPuzzle.Data;

namespace WaterSortPuzzle.Services.PersistentProgress
{
  public interface IPersistentProgressService : IService
  {
    PlayerProgress Progress { get; set; }
  }
}