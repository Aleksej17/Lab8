using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i=0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane)Planes[i]);
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < Planes.Count; i++)
            {
                if (Planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)Planes[i]);
                }
            }
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.PassengersCapacityIs() > x.PassengersCapacityIs() ? w : x);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            for (int i = 0; i < militaryPlanes.Count; i++)
            {
                MilitaryPlane plane = militaryPlanes[i];
                if (plane.PlaneTypeIs() == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }

            return transportMilitaryPlanes;
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MAXFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMS()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MAXLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}


/*
 using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengerPlanes()
        {
            return _planes.OfType<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.OfType<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxCapacity()
        {
            return GetPassengerPlanes().OrderByDescending(plane => plane.PassengersCapacity).FirstOrDefault();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes()
                .Where(plane => plane.Type == MilitaryType.TRANSPORT)
                .ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxFlightDistance).ToList());
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxSpeed).ToList());
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(plane => plane.MaxLoadCapacity).ToList());
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return _planes.AsReadOnly();
        }

        public override string ToString()
        {
            return $"Airport{{ planes={string.Join(", ", _planes.Select(plane => plane.Model))} }}";
        }
    }
}

Изменения и улучшения:
Именование: Поле _planes теперь является readonly, что подчеркивает его неизменность.
LINQ: Использованы методы LINQ (OfType, OrderBy, Where) для упрощения и повышения читабельности кода.
Упрощение методов: Методы GetPassengerPlanes, GetMilitaryPlanes, и GetTransportMilitaryPlanes теперь используют LINQ, что сокращает код и делает его более понятным.
Изменение метода получения максимальной вместимости: Упрощен метод GetPassengerPlaneWithMaxCapacity, который теперь использует OrderByDescending для получения максимального значения.
Улучшение метода ToString: Использована интерполяция строк для большей читабельности.
 */