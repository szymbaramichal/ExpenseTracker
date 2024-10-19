using System;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Shared;
using ExpenseTracker.Infrastructure.Repositories.FamilyRepository;

namespace ExpenseTracker.Business.Services.FamilyService;

public class FamilyService(IFamilyRepository familyRepository) : IFamilyService
{
    public async Task<Result<ICollection<FamilyInfoModel>>> GetFamiliesInfoForUser(int userId)
    {
        var familyNamesAndIds = await familyRepository.GetFamilyNamesAndIds(userId);
        List<FamilyInfoModel> familyInfoModel = new();

        foreach (var nameIdPair in familyNamesAndIds)
        {
            familyInfoModel.Add(new() {
               Id = nameIdPair.Item2,
               Name = nameIdPair.Item1 
            });
        }

        return new Result<ICollection<FamilyInfoModel>>(familyInfoModel);
    }
}
