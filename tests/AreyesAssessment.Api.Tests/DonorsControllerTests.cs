using Moq;
using Xunit;
using AreyesAssessment.API.Controllers;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AreyesAssessment.Api.Tests
{
    public class DonorsControllerTests
    {
        private readonly Mock<IDonorService> _mockDonorService;
        private readonly DonorsController _controller;

        public DonorsControllerTests()
        {
            _mockDonorService = new Mock<IDonorService>();
            _controller = new DonorsController(_mockDonorService.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithDonorDto()
        {
            // Arrange
            int donorId = 1;
            var expectedDonor = new DonorDto { DonorID = donorId, DonorName = "Arian Reyes", Address = "Lima", ActiveStatus = true };
            _mockDonorService.Setup(service => service.GetByIdAsync(donorId)).ReturnsAsync(expectedDonor);

            // Act
            var result = await _controller.GetById(donorId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DonorDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedDonor = Assert.IsType<DonorDto>(okResult.Value);
            Assert.Equal(expectedDonor.DonorID, returnedDonor.DonorID);
            Assert.Equal(expectedDonor.DonorName, returnedDonor.DonorName);
            Assert.Equal(expectedDonor.Address, returnedDonor.Address);
            Assert.Equal(expectedDonor.ActiveStatus, returnedDonor.ActiveStatus);
        }


        [Fact]
        public async Task GetById_ReturnsNotFoundResult_WhenDonorDoesNotExist()
        {
            // Arrange
            int donorId = 1;
            _mockDonorService.Setup(service => service.GetByIdAsync(donorId)).ReturnsAsync((DonorDto)null);

            // Act
            var result = await _controller.GetById(donorId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DonorDto>>(result);
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }


        [Fact]
        public async Task Create_ReturnsCreatedAtActionResult_WithDonorDto()
        {
            // Arrange
            var donorDto = new DonorDto { DonorID = 1, DonorName = "Arian Reyes", Address = "Lima" };
            _mockDonorService.Setup(service => service.CreateAsync(donorDto))
                .ReturnsAsync(donorDto);

            // Act
            var result = await _controller.Create(donorDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DonorDto>>(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<DonorDto>(createdResult.Value);
            Assert.Equal(donorDto.DonorID, returnValue.DonorID);
            Assert.Equal(donorDto.DonorName, returnValue.DonorName);
            Assert.Equal(donorDto.Address, returnValue.Address);
        }


        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("DonorName", "Required");
            var donorDto = new DonorDto { DonorID = 1, Address = "Lima" };

            // Act
            var result = await _controller.Create(donorDto);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DonorDto>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }


        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedDonorDto()
        {
            // Arrange
            var donorDto = new DonorDto { DonorID = 1, DonorName = "Arian Reyes", Address = "Lima" };
            _mockDonorService.Setup(service => service.UpdateAsync(donorDto))
                .ReturnsAsync(donorDto);

            // Act
            var result = await _controller.Update(1, donorDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<DonorDto>(okResult.Value);
            Assert.Equal(donorDto.DonorID, returnValue.DonorID);
            Assert.Equal(donorDto.DonorName, returnValue.DonorName);
            Assert.Equal(donorDto.Address, returnValue.Address);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenDonorDoesNotExist()
        {
            // Arrange
            var donorDto = new DonorDto { DonorID = 1 };
            _mockDonorService.Setup(service => service.UpdateAsync(donorDto))
                .ReturnsAsync((DonorDto)null);

            // Act
            var result = await _controller.Update(1, donorDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDonorIsDeleted()
        {
            // Arrange
            _mockDonorService.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDonorDoesNotExist()
        {
            // Arrange
            _mockDonorService.Setup(service => service.DeleteAsync(1))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
