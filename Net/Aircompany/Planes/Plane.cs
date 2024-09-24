using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string _model;
        public int _maxSpeed;
        public int _maxFlightDistance;
        public int _maxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            _model = model;
            _maxSpeed = maxSpeed;
            _maxFlightDistance = maxFlightDistance;
            _maxLoadCapacity = maxLoadCapacity;
        }

        public string GetModel()
        {
            return _model;
        }

        public int GetMS()
        {
            return _maxSpeed;
        }

        public int MAXFlightDistance()
        {
            return _maxFlightDistance;
        }

        public int MAXLoadCapacity()
        {
            return _maxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{" +
                "model='" + _model + '\'' +
                ", maxSpeed=" + _maxSpeed +
                ", maxFlightDistance=" + _maxFlightDistance +
                ", maxLoadCapacity=" + _maxLoadCapacity +
                '}';
        }

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            return plane != null &&
                   _model == plane._model &&
                   _maxSpeed == plane._maxSpeed &&
                   _maxFlightDistance == plane._maxFlightDistance &&
                   _maxLoadCapacity == plane._maxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_model);
            hashCode = hashCode * -1521134295 + _maxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxLoadCapacity.GetHashCode();
            return hashCode;
        }        

    }
}





/*
 namespace Aircompany.Planes
{
    public abstract class Plane
    {
        private readonly string _model;
        private readonly int _maxSpeed;
        private readonly int _maxFlightDistance;
        private readonly int _maxLoadCapacity;

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            _model = model;
            _maxSpeed = maxSpeed;
            _maxFlightDistance = maxFlightDistance;
            _maxLoadCapacity = maxLoadCapacity;
        }

        public string Model => _model;
        public int MaxSpeed => _maxSpeed;
        public int MaxFlightDistance => _maxFlightDistance;
        public int MaxLoadCapacity => _maxLoadCapacity;

        public override string ToString()
        {
            return $"Plane{{ Model='{_model}', MaxSpeed={_maxSpeed}, MaxFlightDistance={_maxFlightDistance}, MaxLoadCapacity={_maxLoadCapacity} }}";
        }

        public override bool Equals(object plane)
        {
            return plane is Plane plane &&
                   _model == plane._model &&
                   _maxSpeed == plane._maxSpeed &&
                   _maxFlightDistance == plane._maxFlightDistance &&
                   _maxLoadCapacity == plane._maxLoadCapacity;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;
            hashCode = hashCode * 23 + _model.GetHashCode();
            hashCode = hashCode * 23 + _maxSpeed.GetHashCode();
            hashCode = hashCode * 23 + _maxFlightDistance.GetHashCode();
            hashCode = hashCode * 23 + _maxLoadCapacity.GetHashCode();
            return hashCode;
        }
    }
}




Изменения и улучшения:
Именование: Поля переименованы с _ в формат с заглавной буквы (например, Model вместо _model) для улучшения читаемости и соблюдения стандартов C#.
Автоматические свойства: Использованы автоматические свойства для доступа к данным, что упрощает код.
Форматирование строк: Для ToString использован интерполяционный метод форматирования строк, который более читабелен.
Улучшенный метод GetHashCode: Использована более распространенная формула для вычисления хэш-кода, что делает его более надежным.
Упрощенный метод Equals: Проверка на is для лучшего понимания.
 */
