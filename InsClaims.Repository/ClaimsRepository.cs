using System.Security.Claims;
using System.Collections.Generic;
using InsClaims.data;

namespace InsClaims.Repository
{
    public class ClaimsRepository
    {
        //Fake Database of claims : Collection Queue<T>
        private readonly Queue<ClaimFiled> _OrderOfClaims = new Queue<ClaimFiled>();
        private int _idCount = 0;


public ClaimsRepository()
{
    _OrderOfClaims = new Queue<ClaimFiled>();
    Seed();
}

private void Seed()
{
    ClaimFiled Client1 = new ClaimFiled(ClaimType.CAR,"Car On Car Collision, Car Damaging Radiator Spark Plug Components",5650,true);
    ClaimFiled Client2 = new ClaimFiled(ClaimType.HOME,"Client's House Had A Tree Fall On Their Roof And Window", 25000, false  );
    ClaimFiled Client3 = new ClaimFiled(ClaimType.THEFT,"Client Had A KIA Soul And Was An Unfortunate Victim Of The KIA Boyz",15000, true);
    ClaimFiled Client4 = new ClaimFiled(ClaimType.CAR, "Car Blew Up Randomly, Figuring Out Issue Still",12000, false);

    AddClaim(Client1);
    AddClaim(Client2);
    AddClaim(Client3);
    AddClaim(Client4);
}
        //C.R.R.D.
        // Creating an insurance Claim
        public bool AddClaim(ClaimFiled claimFiled)
        {
            if(claimFiled is null)
            {
                return false;
            }
            else
            {
                _idCount++;
                claimFiled.OrderId = _idCount;
                //add to the queue:
                _OrderOfClaims.Enqueue(claimFiled);
                return true;
            }
        }

        //Read a singular Claim
        public ClaimFiled ClaimFileToBeProcessed()
        {
            if(_OrderOfClaims.Count() > 0)
            {
            // Peek(); see the next claim in queue.
            ClaimFiled claimFileToBeProcessed = _OrderOfClaims.Peek();
            return claimFileToBeProcessed;
            }
            else
            {
                return null!;
            }
        } 

            //Reading a LIST of the Claims
        public Queue<ClaimFiled> GetClaimsFiled()
        {
            return _OrderOfClaims;
        }

        // Delete

        public ClaimFiled ProcessClaimFiled()
        {
            if(_OrderOfClaims.Count() > 0)
            {
                ClaimFiled searchClaim = ClaimFileToBeProcessed();
                if(searchClaim != null)
                {
                    ClaimFiled ProcessedClaim = _OrderOfClaims.Dequeue();
                    return ProcessedClaim;
                }
            }
            return null!;
        }

        
        // public bool IsValidClaim(DateTime dateOfClaim, DateTime dateOfIncident)
        // {
        //     //enter date of claim
        //     TimeSpan gracePeriod = dateOfClaim - dateOfIncident;
        //     if(gracePeriod.Days <= 30)
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        //     //enter date of incident
        //     //user fills both sections
        // }

    }
}