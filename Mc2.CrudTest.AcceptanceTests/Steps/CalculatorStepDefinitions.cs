using System.Text;
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
        _customerToAdd = customerName;
        var content = new StringContent(customerName, Encoding.UTF8, "application/json");
        _response = await _client.PostAsync("http://localhost:9090/api/insert", content);
        _response.EnsureSuccessStatusCode();
    }

    [Then(@"the customer ""(.*)"" should be added")]
    public async Task ThenTheCustomerShouldBeAdded(string customerName)
    {
        var response = await _client.GetAsync("http://localhost:9090/api/insert");
        response.EnsureSuccessStatusCode();
        var customers = await response.Content.ReadAsAsync<List<string>>();
        customers.Should().Contain(customerName);
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