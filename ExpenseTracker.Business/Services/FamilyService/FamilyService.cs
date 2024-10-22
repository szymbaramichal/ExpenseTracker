using System;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Shared;
using ExpenseTracker.Infrastructure.Repositories.FamilyRepository;
using System.Net;

namespace ExpenseTracker.Business.Services.FamilyService;

public class FamilyService(IFamilyRepository familyRepository) : IFamilyService
{
    public async Task<Result<FamilyInfoModel>> CreateFamily(int userId, FamilyJoinCreationData familyCreationData)
    {
        var family = new Family {
            Name = familyCreationData.FamilyName,
            Description = familyCreationData.FamilyDescription
        };

        try
        {
            await familyRepository.Create(family, userId);

            var returnModel = new FamilyInfoModel {
                Id = family.Id,
                Name = family.Name,
            };

            return new Result<FamilyInfoModel>(returnModel);
        }
        catch (Exception)
        {
            return new Result<FamilyInfoModel>("Something went wrong", HttpStatusCode.BadRequest);
        }
    }

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
