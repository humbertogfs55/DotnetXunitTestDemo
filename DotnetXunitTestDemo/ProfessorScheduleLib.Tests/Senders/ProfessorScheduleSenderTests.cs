using System;
using Bogus;
using Moq;
using ProfessorScheduleLib.Models;
using ProfessorScheduleLib.Senders;
using ProfessorScheduleLib.Services;

namespace ProfessorScheduleLib.tests.Senders;

public class ProfessorScheduleSenderTests
{
    private readonly Mock<IProfessorScheduleService> _mockProfessorScheduleService;
    private readonly ProfessorScheduleSender _sender;

    public ProfessorScheduleSenderTests()
    {
        // Set up the mock service
        _mockProfessorScheduleService = new Mock<IProfessorScheduleService>();

        // Initialize the controller with the mocked service
        _sender = new ProfessorScheduleSender(_mockProfessorScheduleService.Object);

    }

    [Fact]
    public void SendProfessorSchedule_ReturnsProfessorSchedule()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        
        Assert.Equal(fakeProfessorSchedule.NomeDoProfessor, returnedValue.NomeDoProfessor);
        Assert.Equal(fakeProfessorSchedule.HorarioDeAtendimento, returnedValue.HorarioDeAtendimento);
    }

    // Helper method to generate a fake ProfessorScheduleModel using Bogus
    private ProfessorScheduleModel GenerateFakeProfessorSchedule()
    {
        var faker = new Faker<ProfessorScheduleModel>()
            .RuleFor(p => p.NomeDoProfessor, f => f.Name.FullName())
            .RuleFor(p => p.HorarioDeAtendimento, f => f.Date.FutureOffset().ToString("MMMM dd, yyyy"))
            .RuleFor(p => p.Periodo, f => f.Random.Bool() ? "Integral" : "Noturno")
            .RuleFor(p => p.Sala, f => f.Commerce.Department())
            .RuleFor(p => p.Predio, f => f.Random.ListItems(new List<int> { 1, 2, 3, 4, 5, 6 }, 3));
        
        return faker.Generate();
    }
}
