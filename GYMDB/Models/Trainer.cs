using System;
using System.Collections.Generic;
using System.Text;

namespace GYMDB.Models
{
    public class Trainer : User

    {
        public List<string> Reviews { get; set; }

        public string Comments { get; set; }  // не знаю как назвать, тут записывается краткая или не краткая информация о тренере (заслуги, награды, возможно описание спортивной карьеры и т.д.)
    }
}


// возможно надо добавить поля: стоимость услуг, стаж работы