using System;
using ExpenseTracker.Business.Models.Families;
using ExpenseTracker.Core.Shared;

namespace ExpenseTracker.Business.Services.FamilyService;

public interface IFamilyService
{
    Task<Result<ICollection<FamilyInfoModel>>> GetFamiliesInfoForUser(int userId);
    Task<Result<FamilyInfoModel>> CreateFamily(int userId, FamilyJoinCreationData familyCreationData);
}
