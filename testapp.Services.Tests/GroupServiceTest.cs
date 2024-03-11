using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using testapp.Models.DbModels;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Settings;

namespace testapp.Services.Tests
{
    public class GroupServiceTest
    {
        private Mock<IGroupRepository> _groupRepository;
        private IGroupRepository _mockGroupRepository;
        private GroupService _groupService;
        private IMapper _mapper;
        private List<Group> _fakeGroups;

        private static Random _random;

        public GroupServiceTest()
        {
            GenerateData();
        }

        [Fact]
        public async Task<IEnumerable<Group>> NumberPage_int_Count_int_GetAll_IEnumerable_Group()
        {
            CreateDefaultDeviceServiceInstance();
            var group = await _groupService.GetAllAsync(0 ,5, default(CancellationToken));

            Assert.True(Equals(10, group.Count()));
            return group;
        }
        [Fact]
        public async Task<Group> GuidId_GetAll_Group()
        {
            CreateDefaultDeviceServiceInstance();
            var group = await _groupService.GetByIdAsync(_fakeGroups[0].Id, default(CancellationToken));

            Assert.NotNull(group);
            Assert.True(Equals(group.Name, _fakeGroups[0].Name));
            return group;
        }
        [Fact]
        public async Task Group_AddAsync_Task()
        {
            CreateDefaultDeviceServiceInstance();

        
        }
        private void GenerateData()
        {
            _random = new Random();
            _fakeGroups = new List<Group>();
            for (int i = 0; i < 10; i++)
            {
                _fakeGroups.Add(
                    new Group
                    {
                        Id = Guid.NewGuid(),
                        Name = RandomString(10)
                    });
            }
        }
        private void CreateDefaultDeviceServiceInstance()
        {
            var services = new ServiceCollection();
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var myProfile = new MapperProfile();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(myProfile);
                cfg.ConstructServicesUsing(serviceProvider.GetService);
            });
            _mapper = new Mapper(configuration);

            _groupRepository = new Mock<IGroupRepository>();
            _groupRepository.Setup(s => s.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), default(CancellationToken))).ReturnsAsync(_mapper.Map<List<Group>>(_fakeGroups));
            _groupRepository.Setup(s => s.GetByIdAsync(It.IsAny<Guid>(), default(CancellationToken))).ReturnsAsync(_mapper.Map<Group>(_fakeGroups[0]));
            _groupRepository.Setup(s => s.RemoveAsync(It.IsAny<Group>(), default(CancellationToken)));
            _groupRepository.Setup(s => s.AddAsync(It.IsAny<Group>(), default(CancellationToken)));
            _groupRepository.Setup(s => s.UpdateAsync(It.IsAny<Group>(), default(CancellationToken)));

            _mockGroupRepository = _groupRepository.Object;
            _groupService = new GroupService(_mockGroupRepository, _mapper);
        }
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

         

    }
}