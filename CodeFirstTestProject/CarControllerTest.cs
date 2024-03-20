using CodeFirstPart2.Model;

namespace CodeFirstTestProject
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public async void AllCars_HaveCars_ReturnsListOfCars()
        {
            // Arange
            var cars = new List<Car> { new Car() };
            //var carController = new CarController();

            // Act
            //var result = await CarController
        }

        [TestMethod]
        public async void AllCars_NotHaveCars_ReturnNotFoundCar()
        {
            
        }

        [TestMethod]
        public async void AllCars_HaveCars_ReturnOkStatusCode()
        {

        }

        [TestMethod]
        public async void AddCar_WithValidData_AddCarToRepository()
        {

        }

        [TestMethod]
        public async void AddCar_WithValidData_ReturnOkStatusCode()
        {

        }

        [TestMethod]
        public async void AddCar_InvalidEngineId_ReturnBadRequst()
        {

        }

        [TestMethod]
        public async void UpdateCar_WithValidData_UpdateCarFromRepository()
        {

        }

        [TestMethod]
        public async void UpdateCar_WithValidData_ReturnOkStatusCode()
        {

        }

        [TestMethod]
        public async void UpdateCar_WithInvalidData_ReturnNotFound()
        {

        }

        [TestMethod]
        public async void DeleteCar_ExistingCar_DeleteCarFromRepository()
        {

        }

        [TestMethod]
        public async void DeleteCar_ExistingCar_ReturnOkStatusCode()
        {

        }

        [TestMethod]
        public async void DeleteCar_NonExistingCar_ReturnNotFound()
        {

        }
    }
}