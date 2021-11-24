using System;
using System.Collections.Generic;
using System.Text;

namespace GYMApp.Services.DTO
{
    public class TrainerDTO
    {
        public string FullName { get; set; }
        public string Comments { get; set; }
        public List<ReviewDTO> ReviewsDTO { get; set; } // по идее тренер не должен уметь редактировать отзывы о нем |  также отзыв можно сделать в виде отдельнорго класса (сам отзыв, ссылка на клиента, дата, ID)
    }
}
