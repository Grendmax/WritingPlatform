using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatform.DataLayer.Entities
{
    class MyInitializer : CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            List<Genres> genres = new List<Genres> {
                new Genres {Name = "Фэнтези" },
                new Genres {Name = "Фантастика" },
                new Genres {Name = "Детектив" },
                new Genres {Name = "Классическая литература" },
                new Genres {Name = "Ужасы" },
                new Genres {Name = "Приключения" },
                new Genres {Name = "Боевик" },
                new Genres {Name = "Психология" },
                new Genres {Name = "Культура и искусство" },
                new Genres {Name = "Красота и здоровье" },
                new Genres {Name = "Компьютерная литература" },
                new Genres {Name = "Исторический" },
                new Genres {Name = "Словари, справочники" },
                new Genres {Name = "Юмористическая литература" },
                new Genres {Name = "Наука и образование" }
            };
            context.Genres.AddRange(genres);        

            base.Seed(context);
        }
    }

}
