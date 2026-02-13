using System.Text.RegularExpressions;

namespace CalculateLibrary
{
    // От артемоса: некоторые методы сделал приватными, ибо в других местах они не нужны
    /// <summary>
    /// класс для вычисления математических выражений через обратную польскую запись
    /// </summary>
    public class Calculator
    {
        private static int GetPriora(string op) // нет, не выдача ПРИОРЫ, это метод для определения приоритета оператора
        {
            switch (op)// ор - переменная, содержащая оператор
            {
                case "+": case "-": return 1;
                case "*": case "/": return 2;//имеют приоритет выше, чем сложение и тд
                default: return 0;//прочие операторы обрабатываться не должны
            }
        }

        /// <summary>
        /// разбивает математическое выражение на токены (числа, операторы, скобки)
        /// </summary>
        private static List<string> Tokenize(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))// проверка пустого/нулевого выражения
                throw new ArgumentException("Выражение не может быть пустым.");


            expression = Regex.Replace(expression, @"\s+", ""); // удаляем пробелы для упрощения обработки

            var matches = Regex.Matches(expression, @"(\d+\.?\d*|\.\d+|[+\-*/()])"); // для извлечения чисел (включая десятичные) и операторов/скобок

            if (matches.Count == 0)             // проверка наличия токенов
                throw new ArgumentException("Недопустимое выражение: нет распознаваемых символов.");

            // Проверка на недопустимые символы (всё выражение должно быть распознано)
            int totalLength = 0;
            foreach (Match match in matches)
                totalLength += match.Length;

            if (totalLength != expression.Length)
            {
                // Находим первый недопустимый символ
                for (int i = 0; i < expression.Length; i++)
                {
                    char c = expression[i];
                    if (!"0123456789.+-*/()".Contains(c))
                        throw new ArgumentException($"Недопустимый символ '{c}' в позиции {i + 1}.");
                }
                //  исключение даже если цикл не нашёл символ (теоретически недостижимо)
                throw new ArgumentException("Выражение содержит недопустимые символы.");
            }

            // Формируем список токенов
            var tokens = new List<string>();
            foreach (Match match in matches)
                tokens.Add(match.Value);

            return tokens; // все ветки возвращают значение или бросают исключение
        }


        /// <summary>
        /// преобразует инфиксную запись в постфиксную (обратную польскую запись)
        /// </summary>
        private static List<string> ConvertInfixToPostfix(List<string> tokens)// это всё говно нужно для обратной польской записи
        {
            List<string> output = new List<string>();//создаётся список, куда будет попадать выражение в обратной польской записи
            Stack<string> operators = new Stack<string>();//создаётся стек для операторов 
            foreach (var token in tokens) //перебираем все токены  (части выражения в виде чисел и операторов
            {
                if (double.TryParse(token, out _))//преобразует строку в число, _ означает, что не используется значение, только флаг да или нет 
                {
                    output.Add(token);//если число, то добавляем в постфиксный список
                }
                else if ("+-/*".Contains(token))
                {
                    while (operators.Count > 0 && GetPriora(operators.Peek()) >= GetPriora(token))//
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);//в конце добавляется текущий оператор в стек
                }
                else if (token == "(")//если токен - открывающая скобка, то просто положить в стек
                {
                    operators.Push(token);
                }
                else if (token == ")")//если закрывающая скобка, то : (читать следующие 2 строчки комментария одно предложениеееееееееееееещкере)
                {
                    while (operators.Count > 0 && operators.Peek() != "(")//пока не попадётся ( на вершине стека
                    {
                        output.Add(operators.Pop()); //извлекаем операторы и добавляем в постфиксное выражение
                    }
                    if (operators.Count > 0)
                        operators.Pop(); // удаляет (,
                }
            }
            while (operators.Count > 0)
            {
                output.Add(operators.Pop()); //после обработки токенов извлекаем оставшиеся операторы из стека и добавляем в конечный список
            }
            return output;
        }

        private static double EvaluatePostfix(List<string> postfixTokens)
        {
            Stack<double> stack = new Stack<double>(); //тут создаётся стек для чисел или промежуточных резов
            foreach (var token in postfixTokens) //перебор каждой части выражения в постфикс формате
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number); //если токен число - добавить в стек
                }
                else //если оператор, то берём 2 числа (левое и правое)
                {
                    double right = stack.Pop();
                    double left = stack.Pop();
                    switch (token) //в зависимости от оператора - выполняется вычисление и рез кладётся обратно  стек
                    {
                        case "+":
                            stack.Push(left + right);
                            break;
                        case "-":
                            stack.Push(left - right);
                            break;
                        case "*":
                            stack.Push(left * right);
                            break;
                        case "/":
                            if (right == 0)
                                throw new DivideByZeroException(); //выброс ошибки деления на 0
                            stack.Push(left / right);
                            break;
                    }
                }
            }
            // Проверка корректности результата (в стеке должен остаться ровно 1 элемент)
            if (stack.Count != 1)
                throw new InvalidOperationException("Некорректное выражение: после вычисления в стеке осталось более одного значения.");

            return stack.Pop(); //после обхода остаётся 1 число - ответ

        }
        /// <summary>
        /// главный метод: вычисляет результат математического выражения за один вызов
        /// </summary>
        public static double Calculate(string expression)
        {
            try
            {
                var tokens = Tokenize(expression);
                var postfix = ConvertInfixToPostfix(tokens);
                return EvaluatePostfix(postfix);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException || ex is DivideByZeroException)
            {
                throw;
            }
            catch (Exception ex)
            {
                // обработка любых неожиданных ошибок
                throw new InvalidOperationException($"Ошибка при вычислении выражения: {ex.Message}", ex);
            }
        }
    }
}