using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.BookStoreLibrary
{
    public enum RequestType // Тип запроса покупателя 
    {
        SpecificBook, // Хочет конкретную книгу
        Genre // Хочет любой жанр
    }

    public class Customer
    {
        public int Id { get; private set; } // Уникальный номер
        public RequestType Type { get; private set; }

        
        public string? DesiredTitle { get; private set; } // Для SpecificBook
        public string? DesiredAuthor { get; private set; }       
        public string? DesiredGenre { get; private set; } // Для Genre
        public decimal MaxPrice { get; private set; } // Макс. цена, которую готов заплатить
        public bool IsServed { get; private set; } = false; // статус
        public bool IsLeaving { get; private set; } = false;

        public Customer(int id, RequestType type, string? title, string? author, string? genre, decimal willingToPay)
        {
            Id = id;
            Type = type;
            DesiredTitle = title;
            DesiredAuthor = author;
            DesiredGenre = genre;
            MaxPrice = willingToPay; // Покупатель сам определяет максимальную цену
        }

        /// <summary>
        /// Проверка, подходит ли книга под запрос покупателя
        /// </summary>
        public bool CheckBook(Book book)
        {
            if (book == null) return false;

            if (Type == RequestType.SpecificBook)
            {               
                return string.Equals(book.Title, DesiredTitle, StringComparison.OrdinalIgnoreCase) && // проверка по названию и автору
                       string.Equals(book.Author, DesiredAuthor, StringComparison.OrdinalIgnoreCase);
            }
            else if (Type == RequestType.Genre)
            { 
                return string.Equals(book.Genre, DesiredGenre, StringComparison.OrdinalIgnoreCase); // проверка по жанру
            }

            return false;
        }

        /// <summary>
        /// Проверка цены. Возвращает true, если цена в пределах 15% наценки.
        /// </summary>
        public bool CheckPrice(decimal salePrice)
        {
            return salePrice <= MaxPrice;
        }

        /// <summary>
        /// Покупатель уходит неудовлетворённым 
        /// </summary>
        public void LeaveUnsatisfied()
        {
            IsLeaving = true;
            IsServed = false;
        }

        /// <summary>
        /// Успешная продажа
        /// </summary>
        public void Serve()
        {
            IsServed = true;
            IsLeaving = false;
        }


    }
}
