using HomeWork_OOP_1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest
{
    public class SortedList
    {
        [Fact]
        public void SortListByModel()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "BMW", Price = 25.3, Speed = 100, YearOfExploatation = 15 });
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "Audi", Price = 25.3, Speed = 100, YearOfExploatation = 15 });
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "Ford", Price = 25.3, Speed = 100, YearOfExploatation = 15 });

            var result = cars.OrderBy(x => x.Model);

            Assert.NotNull(result);
        }
        [Fact]
        public void SortListByMark()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "BMW", Price = 25.3, Speed = 100, YearOfExploatation = 15 });
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "Audi", Price = 25.3, Speed = 100, YearOfExploatation = 15 });
            cars.Add(new Car { IsWorking = true, TransportType = "Car", Mark = "X5", Model = "Ford", Price = 25.3, Speed = 100, YearOfExploatation = 15 });

            var result = cars.OrderBy(x => x.Model);
            Assert.NotNull(result);
        }
    }
}
