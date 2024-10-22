using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Enums;
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
            await familyRepository.CreateFamily(family, userId);

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

    public async Task<Result<FamilyViewModel>> GetFamilyDetailsForUser(int userId, int familyId)
    {
        var family = await familyRepository.GetFamilyWithUserIds(familyId);

        if (family is null)
            return new Result<FamilyViewModel>("Family doesn't exist", HttpStatusCode.BadRequest);

        var userInFamilyDetails = family.UserFamilies.FirstOrDefault(x => x.UserId == userId);

        if (userInFamilyDetails is null)
            return new Result<FamilyViewModel>("Family doesn't exist", HttpStatusCode.BadRequest);

        var familyViewModel = new FamilyViewModel {
            Id = family.Id,
            Description = family.Description,
            Name = family.Name,
            IsUserOwner = userInFamilyDetails.FamilyRole == nameof(FamilyRoles.Owner)
        };

        return new Result<FamilyViewModel>(familyViewModel);
    }
}
