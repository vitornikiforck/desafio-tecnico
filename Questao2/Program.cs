using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Questao2;

public partial class Program
{
    static readonly HttpClient httpClient = new HttpClient();

    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    private static int GetTotalScoredGoals(string team, int year)
    {
        int totalScoredGoals = 0;

        totalScoredGoals += HandleGoalsData(team, year, 1);
        totalScoredGoals += HandleGoalsData(team, year, 2);

        return totalScoredGoals;
    }

    private static int HandleGoalsData(string team, int year, int whichTeam)
    {
        int goals = 0;
        string pagesResponse = HandleRequest(team, year);
        var totalPages = JsonConvert.DeserializeObject<ResultPages>(pagesResponse)?.TotalPages;

        for (int i = 1; i <= totalPages; i++)
        {
            var response = HandleRequest(team, year, i, whichTeam);

            var result = JsonConvert.DeserializeObject<Result>(response);
            if (result != null)
            {
                if (whichTeam == 1)
                    goals += result.Data.Sum(x => Convert.ToInt32(x.Team1goals));

                if (whichTeam == 2)
                    goals += result.Data.Sum(x => Convert.ToInt32(x.Team2goals));
            }
        }

        return goals;
    }

    private static string HandleRequest(string team, int year, int page = 1, int whichTeam = 1)
    {
        var uri = new Uri(QueryHelpers.AddQueryString(Constants.URL, GetParams(team, year, page, whichTeam)));
        return httpClient.GetStringAsync(uri).Result;
    }

    private static Dictionary<string, string> GetParams(string team, int year, int page, int wichTeam)
      => new Dictionary<string, string>() { { $"team{wichTeam}", team }, { "year", year.ToString() }, { "page", page.ToString() } };
}