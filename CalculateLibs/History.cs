using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLibs
{
    /// <summary>
    /// Элемент в истории вычислений, содержащий выражение и результат. Позволяет сохранять и отображать историю вычислений в удобном формате.
    /// </summary>
    public class HistoryElement {
        public string Expression { get; set; }
        public double Result { get; set; }

        /// <summary>
        /// Инициализирует новый элемент истории вычислений с заданным выражением и результатом. Это позволяет сохранять и отображать историю вычислений в удобном формате, что может быть полезно для анализа и повторного использования ранее введенных выражений.
        /// </summary>
        /// <param name="expression">Математическое выражение</param>
        /// <param name="result">Результат выражения</param>
        public HistoryElement(string expression, double result)
        {
            Expression = expression;
            Result = result;
        }
    }

    /// <summary>
    /// История вычислений, которая хранит список элементов истории. Позволяет добавлять новые элементы и получать текущую историю для отображения пользователю.
    /// </summary>
    public class History
    {
        private List<HistoryElement> history;
        public event Action<IReadOnlyList<HistoryElement>>? HistoryChanged;

        /// <summary>
        /// Инициализирует новый экземпляр класса History с заданным списком элементов истории. Если переданный список равен null, инициализирует пустой список. Это позволяет создавать историю вычислений с начальным набором данных или без него, что может быть полезно для различных сценариев использования.
        /// </summary>
        /// <param name="initialHistory">Начальная история</param>
        public History(List<HistoryElement>? initialHistory)
        {
            this.history = initialHistory ?? new();
        }
        
        /// <summary>
        /// Добавляет новое выражение и его результат в историю вычислений. Это позволяет пользователю отслеживать свои предыдущие вычисления и их результаты, что может быть полезно для анализа и повторного использования ранее введенных выражений.
        /// </summary>
        /// <param name="expression">Математическое выражение</param>
        /// <param name="result">Результат математического выражения</param>
        public void AddToHistory(string expression, double result)
        {
            HistoryElement newElement = new(expression, result);
            history.Add(newElement);
            HistoryChanged?.Invoke(GetHistory());
        }

        /// <summary>
        /// Возвращает текущую историю вычислений в виде списка элементов истории. Это позволяет пользователю просматривать свои предыдущие вычисления и их результаты, что может быть полезно для анализа и повторного использования ранее введенных выражений.
        /// </summary>
        /// <returns>История вычислений</returns>
        public IReadOnlyList<HistoryElement> GetHistory()
        {
            return history.AsReadOnly();
        }

        /// <summary>
        /// Очистка истории вычислений, удаляя все элементы из списка. Это позволяет пользователю начать новую историю вычислений без сохранения предыдущих данных, что может быть полезно для различных сценариев использования, таких как начало новой сессии или удаление ненужной информации.
        /// </summary>
        public void Clear()
        {
            history.Clear();
            HistoryChanged?.Invoke(GetHistory());
        }
    }
}
