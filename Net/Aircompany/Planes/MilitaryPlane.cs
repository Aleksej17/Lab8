using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType _type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _type = type;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   _type == plane._type;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _type.GetHashCode();
            return hashCode;
        }

        public MilitaryType PlaneTypeIs()
        {
            return _type;
        }


        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + _type +
                    '}');
        }        
    }
}


/*
 using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType planeType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            planeType = type;
        }

        public override bool Equals(object plane)
        {
            return plane is MilitaryPlane plane &&
                   base.Equals(plane) &&
                   planeType.Equals(plane.planeType);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = hashCode * 23 + base.GetHashCode();
            hashCode = hashCode * 23 + planeType.GetHashCode();
            return hashCode;
        }

        public MilitaryType Type => planeType;

        public override string ToString()
        {
            return $"{base.ToString().TrimEnd('}')}, Type={planeType}}";
        }
    }
}

 Изменения и улучшения:
Именование: Поле _type теперь имеет модификатор доступа private и используется с заглавной буквы для свойств.
Автоматическое свойство: Вместо метода PlaneTypeIs используется автоматическое свойство Type, что упрощает доступ к этому значению.
Форматирование строк: Для ToString использован интерполяционный метод форматирования строк для повышения читаемости.
Упрощенный метод Equals: Проверка на is для лучшего понимания и упрощения кода.
Улучшенный метод GetHashCode: Использована более распространенная формула для вычисления хэш-кода.
 */