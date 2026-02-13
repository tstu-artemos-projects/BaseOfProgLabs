using System.Text;

namespace NumberBaseLibs
{
    // От Артёма Клочкова: чутка превожу к действительности, так как в C# числа, которые мы видим, не являются символами, а типами данных, а также хранятся в памяти в двоичном виде.
    public class Convertation
    {
        /// <summary>
        /// Преобразует число из указанной системы счисления в десятичную
        /// </summary>
        /// <param name="num">Строковое представление числа</param>
        /// <param name="baseOfNum">Исходная система счисления </param> - под стандарты лучше приводить (было Base)
        /// <returns>Десятичное представление числа</returns>
        public static int ConvertStringNumberToInteger(string num, int baseOfNum) // Код Марии Титовой (назвапние было ConvertToDecimal)
        {

            // Приводим число к верхнему регистру для единообразия
            num = num.ToUpper();
            int result = 0;

            // Перебор символов числа
            foreach (char digit in num)
            {
                // Преобразование символа в числовое значение
                int digitValue = ConvertCharToIntegerValue(digit);
                // Проверяем, что цифра допустима для данной системы счисления
                if (digitValue >= baseOfNum)
                {
                    return -1;
                }

                result = result * baseOfNum + digitValue;
            }

            return result;
        }

        /// <summary>
        /// Преобразует символ c цифрой в тип числа
        /// </summary>
        /// <param name="digit">Символ цифры</param>
        /// <returns>Число</returns>
        private static int ConvertCharToIntegerValue(char digit) // Тоже код Марии Титовой (название было CharToValue)
        {
            //Преобразование цифры
            if (char.IsDigit(digit))
                return digit - '0';

            //Преобразование буквы
            if (char.IsLetter(digit))
                return digit - 'A' + 10;

            else
                return -1;
        }

        // Документация пишет Артём Клочков, так как Артемий Тактаров (он вообще писал даже консольный пользовательский итнгтефейс) не соизволил этого сделать :)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">Репрезентация числа в памяти дотнета</param>
        /// <param name="baseOfNum">Основание системы исчисления</param>
        /// <returns></returns>
        public static string ConvertIntegerToStringNumber(int number, int baseOfNum) // Код Артемия Тактарова (название было ConvertFromDecimal, baseOfNum было baseTo (вкусовщина, но стандакрты это круто), тип number был long)
        {
            // Проверка допустимости основания
            //if (baseTo < 2 || baseTo > 16)
            //    return "Ошибка! Основание должно быть от 2 до 16. Попробуйте снова";

            if (baseOfNum < 2 || baseOfNum > 16)
                throw new Exception("Ошибка! Основание должно быть от 2 до 16/");

            // лучше высри исключение пж

            // Обработка нуля
            if (number == 0) return "0";

            // Для отрицательных чисел
            bool isNegative = number < 0;
            number = Math.Abs(number);

            StringBuilder result = new StringBuilder();

            // Алгоритм перевода
            while (number > 0)
            {
                int remainder = (int)(number % baseOfNum);

                if (remainder < 10)
                    result.Append(remainder);
                else
                    result.Append((char)('A' + remainder - 10));

                number /= baseOfNum;
            }

            // Добавляем знак, если число было отрицательным
            if (isNegative)
                result.Append('-');

            // Разворачиваем строку (цифры были в обратном порядке) | бро это не совсем строка и тэдэ, это построитель строки, вот его мы и разворачиваем, превращаем в массив, а потом уже превращаем в строку
            return new string(result.ToString().Reverse().ToArray());
        }
    }
}
