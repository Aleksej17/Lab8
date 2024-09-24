using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int _passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   _passengersCapacity == plane._passengersCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _passengersCapacity.GetHashCode();
            return hashCode;
        }

        public int PassengersCapacityIs()
        {
            return _passengersCapacity;
        }

       
        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", passengersCapacity=" + _passengersCapacity +
                    '}');
        }       
        
    }
}


/*
using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private readonly int _passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object plane)
        {
            return plane is PassengerPlane plane &&
                   base.Equals(plane) &&
                   _passengersCapacity == plane._passengersCapacity;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = hashCode * 23 + base.GetHashCode();
            hashCode = hashCode * 23 + _passengersCapacity.GetHashCode();
            return hashCode;
        }

        public int PassengersCapacity => _passengersCapacity;

        public override string ToString()
        {
            return $"{base.ToString().TrimEnd('}')}, PassengersCapacity={_passengersCapacity}}";
        }
    }
}



Изменения и улучшения:
Именование: Поле _passengersCapacity теперь имеет модификатор доступа private и используется с заглавной буквы для свойств (вместо использования _).
Автоматическое свойство: Вместо метода PassengersCapacityIs используется автоматическое свойство PassengersCapacity, что упрощает доступ к этому значению.
Форматирование строк: Для ToString использован интерполяционный метод форматирования строк для повышения читаемости.
Упрощенный метод Equals: Проверка на is для лучшего понимания и упрощения кода.
Улучшенный метод GetHashCode: Использована более распространенная формула для вычисления хэш-кода.
 */