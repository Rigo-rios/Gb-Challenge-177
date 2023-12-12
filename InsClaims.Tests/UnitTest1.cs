using InsClaims.data;
using InsClaims.Repository;

namespace InsClaims.Tests;

public class UnitTest1
{
    private ClaimsRepository _ClaimRepo;
    public UnitTest1()
    {
        _ClaimRepo = new ClaimsRepository();
    }
    



    [Fact]
    public void GetClaimsFiled_Have4Claims()
    {
        // Arrange
        Queue<ClaimFiled> _claimsInDb = _ClaimRepo.GetClaimsFiled();
        // Act
        int expectedCount = 4;
        int actualCount = _claimsInDb.Count();
        //Assert
        Assert.Equal(expectedCount,actualCount);
    }
}