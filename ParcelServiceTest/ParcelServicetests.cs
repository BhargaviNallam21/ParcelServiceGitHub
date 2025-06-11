using AutoMapper;
using Moq;
using ParcelService.DTO;
using ParcelService.Models;
using ParcelService.Services;

namespace ParcelServiceTest
{
    public class ParcelServicetests
    {
        private readonly Mock<IParcelRepository> _mockRepo;
        private readonly ParcelServicecls _service;
        private readonly Mock<IMapper> _mapper;

        public ParcelServicetests()
        {
            _mockRepo = new Mock<IParcelRepository>();
            _mapper = new Mock<IMapper>();
            _service = new ParcelServicecls(_mockRepo.Object, _mapper.Object);
        }
        [Fact]
        public async Task getGetParcelBYID_test()

        {
            var expectedParcel = new Parcel { ParcelId = 1, TrackingNumber = "PKG001" };
            var expectedDto = new ParcelDTO { ParcelId = 1, TrackingNumber = "PKG001" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(expectedParcel);
            _mapper.Setup(m => m.Map<ParcelDTO>(expectedParcel)).Returns(expectedDto);


            var res = await _service.GetParcelBYID(1);
            Assert.NotNull(res);
            Assert.Equal(1, res.ParcelId);
            Assert.Equal("PKG001", res.TrackingNumber);

        }
        [Fact]
        public async Task GetAllParcelsAsync_ReturnsListOfParcels()
        {
            // Arrange
            var parcels = new List<Parcel>
            {
                new Parcel { ParcelId = 3, TrackingNumber="PKG003" },
                new Parcel { ParcelId = 2,  TrackingNumber="PKG002"}
            };
            var expectedparcelsDTO = new List<ParcelDTO>
            {
                new ParcelDTO { ParcelId = 3, TrackingNumber="PKG003" },
                new ParcelDTO { ParcelId = 2,  TrackingNumber="PKG002"}
            };
            _mockRepo.Setup(r => r.GetAllAsync(1, 2)).ReturnsAsync(parcels);
            _mapper.Setup(m => m.Map<List<ParcelDTO>>(parcels)).Returns(expectedparcelsDTO);
            // Act
            var result = await _service.GetAllParcels(1, 2);

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result,
        item => Assert.Equal("PKG003", item.TrackingNumber),
        item => Assert.Equal("PKG002", item.TrackingNumber));
        }
    }
}