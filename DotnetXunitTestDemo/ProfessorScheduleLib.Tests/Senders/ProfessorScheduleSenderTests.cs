using System;
using Bogus;
using Microsoft.Extensions.Hosting;
using Moq;
using ProfessorScheduleLib.Models;
using ProfessorScheduleLib.Senders;
using ProfessorScheduleLib.Services;
using System.Globalization;

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
    #region Success Tests

    [Fact]
    public void SendProfessorSchedule_ShouldReturnProfessorSchedule()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);

        Assert.Equal(fakeProfessorSchedule.ProfessorName, returnedValue.ProfessorName);
        Assert.Equal(fakeProfessorSchedule.Schedule, returnedValue.Schedule);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldReturnValidRoomNumber()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);

        Assert.InRange<int>(int.Parse(returnedValue.Room), 1, 25);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldReturnValidBuildingNumber()
    {
        // Arrange:
        var buildingList = new List<int> { 1, 2, 3, 4, 6 };
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);

        Assert.Contains(buildingList, returnedValue.Building.Contains);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldReturnOnlyOneBuilding()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);

        Assert.Single(returnedValue.Building);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldHaveValidProfessorName()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        Assert.False(string.IsNullOrEmpty(returnedValue.ProfessorName));
    }
    [Fact]
    public void SendProfessorSchedule_ShouldHaveFutureSchedule()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        DateTime horarioDeAtendimento;
        Assert.True(DateTime.TryParse(returnedValue.Schedule, out horarioDeAtendimento));
        Assert.True(horarioDeAtendimento > DateTime.Now);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldHaveValidPeriod()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        Assert.True(returnedValue.Period == "Integral" || returnedValue.Period == "Noturno");
    }
    [Fact]
    public void SendProfessorSchedule_ShouldHaveNonEmptyBuilding()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        Assert.NotEmpty(returnedValue.Building);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldNotContainDuplicateBuildingValues()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        Assert.Equal(returnedValue.Building.Distinct().Count(), returnedValue.Building.Count);
    }
    [Fact]
    public void SendProfessorSchedule_ShouldHaveCorrectScheduleFormat()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule();
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert:
        var returnedValue = Assert.IsType<ProfessorScheduleModel>(result);
        var Schedule = returnedValue.Schedule;
        DateTime parsedDate;

        // Check if the date string is in the correct format
        var isValidFormat = DateTime.TryParseExact(Schedule, "MMMM dd, yyyy",
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out parsedDate);

        Assert.True(isValidFormat);
    }

    #endregion
    [Fact]
    public void SendProfessorSchedule_ShouldNotReturnProfessorSchedule()
    {
        // Arrange:
        var fakeProfessorSchedule = GenerateFakeProfessorSchedule(false);
        _mockProfessorScheduleService.Setup(service => service.GetProfessorSchedule())
                                     .Returns(fakeProfessorSchedule);

        // Act: 
        var result = _sender.SendGetProfessorSchedule();

        // Assert: 
        Assert.Null(result);
    }

    // Helper method to generate a fake ProfessorScheduleModel using Bogus
    private ProfessorScheduleModel? GenerateFakeProfessorSchedule(bool happy = true)
    {
        var faker = new Faker<ProfessorScheduleModel>()
            .RuleFor(p => p.ProfessorName, f => f.Name.FullName())
            .RuleFor(p => p.Schedule, f => f.Date.FutureOffset().ToString("MMMM dd, yyyy"))
            .RuleFor(p => p.Period, f => f.Random.Bool() ? "Integral" : "Noturno")
            .RuleFor(p => p.Room, f => f.Random.Int(1, 25).ToString())
            .RuleFor(p => p.Building, (f, p) => GetBuildingBasedOnRoom(p.Room, f));

        if (happy)
        {
            return faker.Generate();
        }
        else
        {
            return null;
        }
    }

    private static List<int> GetBuildingBasedOnRoom(string room, Faker f)
    {
        var roomNumber = int.Parse(room);
        var buildingList = new List<int> { 1, 2, 3, 4, 6 };

        if (roomNumber <= 5)
        {
            return new List<int> { 1 }; // Assign building number 1 if Sala is less than 5
        }
        else if (roomNumber <= 10 & roomNumber > 5)
        {
            return new List<int> { 2 }; // Assign building number 2 if Sala is between 5 and 15
        }
        else if (roomNumber <= 15 & roomNumber > 10)
        {
            return new List<int> { 3 };
        }
        else if (roomNumber <= 20 & roomNumber > 15)
        {
            return new List<int> { 4 };
        }
        else if (roomNumber <= 25 & roomNumber > 20)
        {
            return new List<int> { 6 };
        }

        return new List<int> { };
    }
}
