using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace BankTest.Services;
public class ApiService
{
    private const string ApiBaseUrl = "https://wryty.ru/api.php";

    public async Task<List<Branch>> GetBranches()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(ApiBaseUrl);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var branchesWrapper = JsonConvert.DeserializeObject<BranchesWrapper>(content);
            return branchesWrapper.Branches;
        }

        return null;
    }
    private class BranchesWrapper
    {
        public List<Branch> Branches { get; set; }
    }
}
