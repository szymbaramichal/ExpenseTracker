using System;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Business.Services.FamilyService;

public interface IFamilyService
{
    Task<Result<FamilyViewModel>> GenerateInvitationCode(int familyId, int userId);
    Task<Result<FamilyViewModel>> JoinFamily(int userId, string inviteCode);
    Task<Result<ICollection<FamilyInfoModel>>> GetFamiliesInfoForUser(int userId);
    Task<Result<FamilyViewModel>> GetFamilyDetailsForUser(int userId, int familyId);
    Task<Result<FamilyInfoModel>> CreateFamily(int userId, FamilyJoinCreationData familyCreationData);
}
