using System.Text;
using System.Text.Json;
using FluentAssertions;


namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private HttpClient _client;
    private HttpResponseMessage _response;
    private string _customerToAdd;
    private List<string> _customers;

    public CalculatorStepDefinitions()
    {
        _client = new HttpClient();
        _customers = new List<string>();
    }

    [Given(@"the API is running")]
    public void GivenTheAPIIsRunning()
    {
        // Assume API is running and accessible
    }

    [When(@"I add a customer with the name ""(.*)""")]
    public async Task WhenIAddACustomerWithTheName(string customerName)
    {
        Customer customer = new Customer
        {
            FirstName = customerName,
            PhoneNumber = "+902123456789",
            BankAccountNumber = "123456",
            DateOfBirth = DateTime.Now,
            Email = "test1@test.com",
            LastName = customerName
        };
        var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("http://localhost:9090/api/insert", content);
        _response.EnsureSuccessStatusCode();
    }

    [Then(@"the customer ""(.*)"" should be added")]
    public async Task ThenTheCustomerShouldBeAdded(string customerName)
    {
        var response = await _client.GetAsync("http://localhost:9090/api/getall");
        response.EnsureSuccessStatusCode();
        var customers = await response.Content.ReadAsAsync<List<Customer>>();
        customers.Select(x => x.FirstName).Should().Contain(customerName);
    }

    [When(@"I retrieve the list of customers")]
    public async Task WhenIRetrieveTheListOfCustomers()
    {
        // Assume I received
    }

    [Then(@"the list should contain the name ""(.*)""")]
    public async Task ThenTheListShouldContainTheName(string customerName)
    {
        var response = await _client.GetAsync("http://localhost:9090/api/getall");
        response.EnsureSuccessStatusCode();
        var customers = await response.Content.ReadAsAsync<List<Customer>>();
        customers.Select(x => x.FirstName).Should().Contain(customerName);
    }

    //private readonly ScenarioContext _scenarioContext;

    //public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    //{
    //    _scenarioContext = scenarioContext;
    //}

    //[Given("to be filled...")]
    //public void GivenTheFirstNumberIs(int number)
    //{

    //    _scenarioContext.Pending();
    //}

    //[When("to be filled...")]
    //public void WhenTheTwoNumbersAreAdded()
    //{
    //    //TODO: implement act (action) logic

    //    _scenarioContext.Pending();
    //}

    //[Then("to be filled...")]
    //public void ThenTheResultShouldBe(int result)
    //{
    //    //TODO: implement assert (verification) logic

    //    _scenarioContext.Pending();
    //}
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}