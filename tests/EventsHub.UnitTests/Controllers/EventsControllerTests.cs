using System;
using System.Threading.Tasks;
using EventsHub.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EventsHub.UnitTests.Controllers;

[TestFixture]
public class EventsControllerTests
{
    private EventsController _eventsController;

    [SetUp]
    public void Setup()
    {
        _eventsController = new EventsController(GlobalTestSetup.AppDbContext);
    }

    [Test]
    public async Task GetActivitiesAsync_WhenEventsExist_ReturnsAllEvents()
    {
        // Arrange
        var expectedCount = await GlobalTestSetup.AppDbContext.Activities.CountAsync();

        // Act: Nombre exacto del método en el Controller
        var result = await _eventsController.GetActivitiesAsync();

        // Assert
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value, Has.Count.EqualTo(expectedCount));
    }

    [Test]
    public async Task GetActivityDetailAsync_WhenEventExists_ReturnsMatchingEvent()
    {
        // Arrange
        var existing = await GlobalTestSetup.AppDbContext.Activities.FirstAsync();

        // Act: Nombre exacto del método en el Controller
        var result = await _eventsController.GetActivityDetailAsync(existing.Id);

        // Assert
        Assert.That(result.Value, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Value.Id, Is.EqualTo(existing.Id));
            Assert.That(result.Value.Title, Is.EqualTo(existing.Title));
        });
    }

    [Test]
    public async Task GetActivityDetailAsync_WhenEventDoesntExist_ReturnsNotFound()
    {
        // Arrange: Se pasa un string porque la firma de tu Controller recibe (string id)
        var nonExistentId = Guid.NewGuid().ToString();

        // Act
        var result = await _eventsController.GetActivityDetailAsync(nonExistentId);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());

        var notFoundResult = (NotFoundObjectResult)result.Result;

        Assert.Multiple(() =>
        {
            Assert.That(notFoundResult.Value, Is.EqualTo("The event was not found"));
            Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
        });
    }
}