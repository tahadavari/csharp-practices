using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Pokemon.Controllers;
using Pokemon.Dto;
using Pokemon.Interfaces;

namespace TestPokemon.Controller
{
    public class CategoryController2Tests
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;
        public CategoryController2Tests()
        {
            _categoryRepository = A.Fake<ICategoryRepository>();
            _mapper = A.Fake<IMapper>();

            var webAppFactory = new WebApplicationFactory<Program>();
            var client =    
        }

        [Fact]
        public void PokemonController_GetCategory_ReturnOK()
        {
            //Arrange
            var categories = A.Fake<ICollection<CategoryDto>>();
            var categoryList = A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categories)).Returns(categoryList);
            var controller = new CategoryController(_categoryRepository, _mapper);

            //Act
            var result = controller.GetCategories();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        
    }
}
