using System;
using System.Collections.Generic;
using System.Linq;
using Bham.Plaid.Institution;
using Xunit;

namespace Bham.Plaid.Test
{
    public class InstitutionTests
    {
        [Fact]
        public async void GetTest()
        {
            const string clientId = "5e4c1c52b83f3800124fc525";
            const string clientSecret = "93c8b61ef98301c4bac73677b8be73";
            const string publicKey = "ef0d740aef5ab5b25d094ad150ed05";

            var client = new PlaidClient(Environment.Sandbox);
            var institutionRequest = new GetRequest()
            {
                Count = 10,
                Offset = 0,
                ClientId = clientId,
                Secret = clientSecret
            };
            var institutionResults = await client.FetchAllInstitutionsAsync(institutionRequest);
            Assert.Null(institutionResults.Exception);
            Assert.True(institutionResults.Institutions.Length == 10);
        }
        [Fact]
        public async void SearchTest()
        {
            const string clientId = "5e4c1c52b83f3800124fc525";
            const string clientSecret = "93c8b61ef98301c4bac73677b8be73";
            const string publicKey = "ef0d740aef5ab5b25d094ad150ed05";

            var client = new PlaidClient(Environment.Sandbox);
            var institutionRequest = new SearchByIdRequest()
            {
                PublicKey = publicKey,
                
            };
            var institutionResults = await client.FetchInstitutionsAsync(institutionRequest);
            Assert.Null(institutionResults.Exception);
            Assert.True(institutionResults.Institutions.Length == 10);
        }
        [Fact]
        public async void GetByIdTest()
        {
            const string clientId = "5e4c1c52b83f3800124fc525";
            const string clientSecret = "93c8b61ef98301c4bac73677b8be73";
            const string publicKey = "ef0d740aef5ab5b25d094ad150ed05";

            var client = new PlaidClient(Environment.Sandbox);
            var institutionRequest = new GetRequest()
            {
                Count = 1,
                Offset = 0,
                ClientId = clientId,
                Secret = clientSecret
            };
            var institutionResults = await client.FetchAllInstitutionsAsync(institutionRequest);
            Assert.Null(institutionResults.Exception);
            Assert.True(institutionResults.IsSuccessStatusCode);
            Assert.True(institutionResults.Institutions.Length == 1);
            var idRequest = new SearchByIdRequest()
            {
                PublicKey = publicKey,
                InstitutionId = institutionResults.Institutions.FirstOrDefault()?.Id
            };
            var idResults = await client.FetchInstitutionByIdAsync(idRequest);
            Assert.Null(idResults.Exception);
            Assert.True(idResults.IsSuccessStatusCode);
            Assert.NotNull(idResults.Institution);
        }
    }
}
