using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Enums;
using ExpenseTracker.Core.Shared;
using ExpenseTracker.Infrastructure.Repositories.FamilyRepository;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;

namespace ExpenseTracker.Business.Services.FamilyService;

public class FamilyService(IFamilyRepository familyRepository, IDistributedCache _cache) : IFamilyService
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


    public async Task<Result<FamilyViewModel>> GenerateInvitationCode(int familyId, int userId)
    {
        var family = await familyRepository.GetFamilyWithUserIds(familyId);

        if (family is null)
            return new Result<FamilyViewModel>("Family doesn't exist", HttpStatusCode.BadRequest);

        var userInFamilyDetails = family.UserFamilies.FirstOrDefault(x => x.UserId == userId);

        if (userInFamilyDetails is null || userInFamilyDetails.FamilyRole != nameof(FamilyRoles.Owner))
            return new Result<FamilyViewModel>("Family doesn't exist", HttpStatusCode.BadRequest);

        string invitationCode = GenerateRandomCode();

        _cache.SetString(invitationCode, familyId.ToString(), new DistributedCacheEntryOptions {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(2)
        });

        var familyViewModel = new FamilyViewModel {
            Id = family.Id,
            Description = family.Description,
            Name = family.Name,
            IsUserOwner = userInFamilyDetails.FamilyRole == nameof(FamilyRoles.Owner),
            FamilyInvitationCode = invitationCode
        };

        return new Result<FamilyViewModel>(familyViewModel);
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

    public async Task<Result<FamilyViewModel>> JoinFamily(int userId, string inviteCode)
    {
        var familyId = _cache.GetString(inviteCode);

        if(string.IsNullOrEmpty(familyId))
            return new Result<FamilyViewModel>("Invalid invitation code. ", HttpStatusCode.BadRequest);

        var userInfoForFamily = await familyRepository.GetUserInfoForFamily(int.Parse(familyId), userId);

        if(userInfoForFamily is not null)
            return new Result<FamilyViewModel>("You already are part of this family", HttpStatusCode.BadRequest);

        var userFamily = new UserFamily {
            FamilyId = int.Parse(familyId),
            UserId = userId,
            FamilyRole = nameof(FamilyRoles.Normal)
        };

        await familyRepository.AddUserToFamily(userFamily);

        var family = await familyRepository.GetFamilyWithUserIds(int.Parse(familyId));

        var familyViewModel = new FamilyViewModel {
            Id = family.Id,
            Description = family.Description,
            Name = family.Name,
            IsUserOwner = false,
            FamilyInvitationCode = string.Empty
        };

        return new Result<FamilyViewModel>(familyViewModel);
    }

    private string GenerateRandomCode(int length = 6)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] result = new char[length];

        Random rnd = new Random();

        for(int i = 0; i < length; i++)
        {
            int indexNum = rnd.Next(0, 36);
            result[i] = chars[indexNum];
        }

        return new string(result);
    }
}
