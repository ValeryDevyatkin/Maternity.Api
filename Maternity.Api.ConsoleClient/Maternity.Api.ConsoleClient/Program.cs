using Maternity.Domain.Model;
using System.Net.Http.Json;

namespace Maternity.Api.ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var patients = new List<Patient>();
            for (var i = 0; i < 100; i++)
            {
                var patient = new Patient
                {
                    Active = true,
                    FamilyName = $"Family Name #{i}",
                    Gender = i % 2 == 2 ? "Male" : "Female",
                    Name = [$"Name #{i}", $"Father Name #{i}"],
                    BirthDate = DateTime.Now.AddMonths(i * (-1))
                };
                patients.Add(patient);
            }

            try
            {
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:5082/api/patients/bulk", patients);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                responseString = string.IsNullOrWhiteSpace(responseString) ? "RESPONSE STRING PLACEHOLDER" : responseString;

                Console.WriteLine($"Success: [{responseString}].");
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
