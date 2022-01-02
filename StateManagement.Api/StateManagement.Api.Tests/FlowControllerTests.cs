using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using StateManagement.Api.Controllers;
using StateManagement.Business.Services.Base;
using StateManagement.Data.Entities;
using System.Threading;

namespace StateManagement.Api.Tests
{
    class FlowControllerTests
    {
        private IFlowService _flowService;
        private ILogger<FlowController> _logger;

        private FlowController _controller;

        [SetUp]
        public void SetUp()
        {
            _flowService = Mock.Of<IFlowService>();
            _logger = Mock.Of<ILogger<FlowController>>();

            _controller = new FlowController(_flowService, _logger);
        }

        [Test]
        public async System.Threading.Tasks.Task GetFlowAsync_ReturnsFlowAsync()
        {
            var flowId = 1;
            var flow = new Flow();
            var flowServiceMock = Mock.Get(_flowService);

            flowServiceMock.Setup(s => s.GetFlowAsync(flowId, CancellationToken.None))
                .ReturnsAsync(flow)
                .Verifiable();

            var actual = await _controller.GetFlowAsync(flowId, CancellationToken.None);

            actual.Should().BeEquivalentTo(flow);
        }
    }
}
